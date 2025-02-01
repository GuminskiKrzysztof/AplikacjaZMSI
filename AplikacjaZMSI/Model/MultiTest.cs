using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI.Model
{
    public class MultiTest
    {
        private Func<int, bool> progres;
        private List<IOptimizationAlgorithm> testList;
        private Func<double[], double> TestFunc;
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
                i+=1;
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
   

            foreach (var alg in algoritms)
            {
                if (alg == "AO")
                {
                    foreach (var param1 in new double[] { 0.01,0.05,0.1,0.2,0.3,0.4,0.5})
                        foreach (var param2 in new double[] { 0.01, 0.05, 0.1, 0.2, 0.3, 0.4, 0.5 })
                            foreach (var param3 in new double[] {-1.0,-0.5,0.0,0.5,1.0,1.5,2.0,2.5 })
                            {
                                AquilaOptimizer ao = new AquilaOptimizer();
                                ao.init(TestFunc,new double[,] { { -5,5}, { -5, 5 } }, new double[] { param1, param2, param3 });
                                testList.Add(ao);
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
                                testList.Add(boa);
                            }
                }
            }  
        }

    }
}
