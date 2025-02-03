using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AplikacjaZMSI.Model
{
    public class MultiTest
    {
        private Func<int, bool> progres;
        private List<IOptimizationAlgorithm> testList;
        private Func<double[], double> TestFunc;
        private List<string> jsonStrings;
        public MultiTest(Func<int,bool> pr)
        {
            testList = new List<IOptimizationAlgorithm>();
            progres = pr;
            progres.Invoke(0);
        }
        public void run(string testFunc, List<string> algoritms )
        {
            Console.Write(testFunc);
            createTests(testFunc,algoritms);
            double i = 0;
            foreach (var test in testList)
            {
                test.Solve();
               

                i +=1;
                progres.Invoke((int)((i / (double)testList.Count) * 100));
                
            }
            //for
            //test
            // prog update

        }

        private void createTests( string testFunc,List<string> algoritms)
        {

            if(testFunc == "Sphere")
            {
                TestFunc = TestFunction.Sphere;
            }
            else if (testFunc == "Rastrigin")
            {
                TestFunc = TestFunction.Rastrigin;
            }
            else if (testFunc == "Rosenbrock")
            {
                TestFunc = TestFunction.Rosenbrock;
            }
            else if (testFunc == "Beale")
            {
                TestFunc = TestFunction.Beale;
            }

            JObject combinedData = new JObject();
            int i = 0;
            foreach (var alg in algoritms)
            {
                
                if (alg == "AO")
                {
                    foreach (var param1 in new double[] { 0.01, 0.05, 0.1, 0.2, 0.3, 0.4, 0.5 })
                        foreach (var param2 in new double[] { 0.01, 0.05, 0.1, 0.2, 0.3, 0.4, 0.5 })
                            foreach (var param3 in new double[] { -1.0, -0.5, 0.0, 0.5, 1.0, 1.5, 2.0, 2.5 })
                            {

                                AquilaOptimizer ao = new AquilaOptimizer();
                                ao.init(TestFunc, new double[,] { { -5, 5 }, { -5, 5 } }, new double[] { param1, param2, param3 });
                                testList.Add(ao);
                                ao.setFuncName(testFunc);
                                string key = $"Data{i + 1}";
                                JObject jsonObject = JObject.Parse(ao.getJson());
                                combinedData[key] = jsonObject;
                                i++;
                            }
                    
                }
     
                else if(alg == "BOA")
                {
                    foreach (var param1 in new double[] { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 })
                        foreach (var param2 in new double[] { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 })
                            foreach (var param3 in new double[] {0.1, 0.2, 0.3, 0.4, 0.5,0.6,0.7,0.8,0.9 })
                            {
                                BOAAlgorithm boa = new BOAAlgorithm();
                                boa.init(TestFunc, new double[,] { { -5, 5 }, { -5, 5 } }, new double[] { param1, param2, param3 });
                                boa.setFuncName(testFunc);
                                testList.Add(boa);
                                string key = $"Data{i + 1}";
                                JObject jsonObject = JObject.Parse(boa.getJson());
                                Console.WriteLine(jsonObject.ToString());
                                combinedData[key] = jsonObject;
                                i++;

                        }
                }
            }
            File.WriteAllText("multitest.json", combinedData.ToString());
        }

    }
}
