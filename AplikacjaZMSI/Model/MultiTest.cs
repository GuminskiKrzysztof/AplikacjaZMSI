﻿using System;
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
        JObject combinedData;

        public MultiTest(Func<int,bool> pr)
        {
            testList = new List<IOptimizationAlgorithm>();
            progres = pr;
            progres.Invoke(0);
        }
        public MultiTest(Func<int, bool> pr, string json)
        {
            List<TestData> dataList = new List<TestData>();
            dataList = JsonConvert.DeserializeObject<List<TestData>>(json);
            testList = new List<IOptimizationAlgorithm>();
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
            File.WriteAllText("multitest.json", combinedData.ToString());

            progres = pr;
            progres.Invoke((int)i);

            for (int u = (int)i; u < testList.Count; u++)
            {
                testList[u].Solve();
                string key = $"Data{u + 1}";
                testList[u].setPopNull();
                JObject jsonObject = JObject.Parse(testList[u].getJson());
                combinedData[key] = jsonObject;
                File.WriteAllText("multitest.json", combinedData.ToString());
                progres.Invoke((int)(((double)u / (double)testList.Count) * 100));
            }
            File.Delete("multitest.json");
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
                File.WriteAllText("multitest.json", combinedData.ToString());
                i +=1;
                progres.Invoke((int)((i / (double)testList.Count) * 100));
            }
            File.Delete("multitest.json");
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

            combinedData = new JObject();
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
