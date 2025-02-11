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
        public List<IOptimizationAlgorithm> testList;
        private Func<double[], double> TestFunc;
        JObject combinedData;

        public MultiTest(Func<int,bool> pr)
        {
            testList = new List<IOptimizationAlgorithm>();
            progres = pr;
            progres.Invoke(0);
        }

        public List<TestData> getbest()
        {
            List<TestData> r = new List<TestData>();
            double mini = 1000000000000;
            TestData m = new TestData();
            if (testList[0].data.name[0] == 'A')
            {
                foreach (var test in testList)
                {
                    if (test.data.name[0] == 'A')
                        if (test.data.FBest < mini)
                        {
                            mini = test.data.FBest;
                            m = test.data;

                        }

                }
                r.Add(m);
            }

            mini = 1000000000000;
            if (testList[testList.Count - 1].data.name[0] == 'B')
            {
                foreach (var test in testList)
                {
                    if (test.data.name[0] == 'B')
                        if (test.data.FBest < mini)
                        {
                            mini = test.data.FBest;
                            m = test.data;

                        }

                }
                r.Add(m);
            }


            return r;
        }


        public MultiTest(Func<int, bool> pr, string json)
        {
            Dictionary<string, TestData> dataDict = JsonConvert.DeserializeObject<Dictionary<string, TestData>>(json);
            testList = new List<IOptimizationAlgorithm>();
            List<TestData> dataList = dataDict.Values.ToList();
            List<string> list = new List<string>();
            if (dataList[0].name[0] == 'A') list.Add("AO");
            if(dataList[dataList.Count-1].name[0] == 'B') list.Add("BOA");
            createTests(dataList[0].func, list);
            double i = 0;
            
            // Deserialize JSON into a List<TestData>
            
            Console.WriteLine("Loaded TestData objects:");
            foreach (var data in dataList)
                {
                    Console.WriteLine($"Name: {data.name}, Param1: {data.param1}, Param2: {data.param2}");
                }
            
            for (int u = 0; u < testList.Count; u++)
            {
                testList[u].setJson(dataList[u]);
                string key = $"Data{u + 1}";
                combinedData[key] = JObject.Parse(testList[u].getJson());
                if (dataList[u].state == "DONE") i++;
            }
            File.WriteAllText("multitest_.json", combinedData.ToString());
            File.Copy("multitest_.json", "multitest.json", true);

            progres = pr;
            progres.Invoke((int)((i / (double)testList.Count) * 100));

            for (int u = (int)i; u < testList.Count; u++)
            {
                testList[u].Solve();
                string key = $"Data{u + 1}";
                testList[u].setPopNull();
                JObject jsonObject = JObject.Parse(testList[u].getJson());
                combinedData[key] = jsonObject;
                File.WriteAllText("multitest_.json", combinedData.ToString());
                File.Copy("multitest_.json", "multitest.json", true);
                progres.Invoke((int)(((double)(u+1) / (double)testList.Count) * 100));
            }
            File.Delete("multitest_.json");
            File.Delete("multitest.json");
            PDFReportGenerator e = new PDFReportGenerator();
            Console.WriteLine(getbest());
            e.Milti(getbest());
        }

        public void run(string testFunc, List<string> algoritms )
        {
            createTests(testFunc,algoritms);
            double i = 0;
            foreach (var test in testList)
            {
                test.Solve();
                string key = $"Data{i + 1}";
                test.setPopNull();
                JObject jsonObject = JObject.Parse(test.getJson());
                combinedData[key] = jsonObject;
                File.WriteAllText("multitest_.json", combinedData.ToString());
                File.Copy("multitest_.json", "multitest.json", true);
                i +=1;
                progres.Invoke((int)((i / (double)testList.Count) * 100));
            }
            File.Delete("multitest.json");
            File.Delete("multitest_.json");
            PDFReportGenerator e = new PDFReportGenerator();
            Console.WriteLine(getbest());
            e.Milti(getbest());
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
            else if (testFunc == "TSFDE")
            {
                TSFDE_fractional_boundary tsfde_inv = new TSFDE_fractional_boundary();
                TestFunc = tsfde_inv.fintnessFunction;
            }
            else if (testFunc == "OF")
            {
                ObjectiveFunction of = new ObjectiveFunction();
                TestFunc = of.FunkcjaCelu.Wartosc;
            }

            combinedData = new JObject();
            int i = 0;
            foreach (var alg in algoritms)
            {
                
                if (alg == "AO")
                {
                    foreach (var param1 in new double[] { 0.01, 0.1, 0.2, 0.4, 0.5 })
                        foreach (var param2 in new double[] { 0.01, 0.1, 0.2, 0.4, 0.5 })
                            foreach (var param3 in new double[] { -1.0, 0.0, 0.5, 1.5, 2.0, 2.5 })
                                foreach (var param4 in new double[] { 10, 50, 100, 150 })
                                    foreach (var param5 in new double[] { 10, 50, 100, 150 })
                                    {

                                        AquilaOptimizer ao = new AquilaOptimizer();
                                        if (testFunc == "TSFDE")
                                        {
                                            double[] a = { 0.1, 1.1, 1.0, -70.0, 250.0, -30.0, 50.0 };
                                            double[] b = { 0.9, 1.9, 5.0, -20.0, 450.0, -10.0, 250.0 };
                                            double[,] dom = new double[7, 2];
                                            for (int j = 0; j < 7; j++)
                                            {
                                                dom[j, 0] = a[j];
                                                dom[j, 1] = b[j];
                                            }
                                            ao.init(TestFunc, dom, new double[] { param1, param2, param3, param4, param5 });
                                        }
                                        else
                                            ao.init(TestFunc, new double[,] { { -5, 5 }, { -5, 5 } }, new double[] { param1, param2, param3,param4, param5 });
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
                    foreach (var param1 in new double[] { 0.1, 0.2, 0.4, 0.5, 0.7, 0.8, 0.9 })
                        foreach (var param2 in new double[] { 0.1, 0.2, 0.4, 0.5, 0.7, 0.8, 0.9 })
                            foreach (var param3 in new double[] {0.1, 0.2, 0.4, 0.5,0.7,0.8,0.9 })
                                foreach (var param4 in new double[] { 10,50,100,150 })
                                    foreach (var param5 in new double[] { 10, 50, 100, 150 })
                                    {
                                        BOAAlgorithm boa = new BOAAlgorithm();
                                        if (testFunc == "TSFDE")
                                        {
                                            double[] a = { 0.1, 1.1, 1.0, -70.0, 250.0, -30.0, 50.0 };
                                            double[] b = { 0.9, 1.9, 5.0, -20.0, 450.0, -10.0, 250.0 };
                                            double[,] dom = new double[7, 2];
                                            for (int j = 0; j < 7; j++)
                                            {
                                                dom[j, 0] = a[j];
                                                dom[j, 1] = b[j];
                                            }
                                            boa.init(TestFunc, dom , new double[] { param1, param2, param3, param4, param5 });
                                        }
                                        else
                                            boa.init(TestFunc, new double[,] { { -5, 5 }, { -5, 5 } }, new double[] { param1, param2, param3, param4, param5 });

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
            File.WriteAllText("multitest_.json", combinedData.ToString());
            File.Copy("multitest_.json", "multitest.json", true);
        }

    }
}
