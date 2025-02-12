﻿using MathNet.Numerics.Distributions;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace AplikacjaZMSI.Model
{
    public class BOAAlgorithm : IOptimizationAlgorithm
    {
        public string Name { get; set; } = "Butterfly Optimization Algorithm (BOA)";

        public ParamInfo[] ParamsInfo { get; set; } = new ParamInfo[]
        {
            new ParamInfo { Name = "a", Description = "Parametr a (współczynnik w BOA)", LowerBoundary = 0.1, UpperBoundary = 1.0, IsInteger = false },
            new ParamInfo { Name = "c", Description = "Parametr c (intensywność zapachu)", LowerBoundary = 0.1, UpperBoundary = 2.0, IsInteger = false },
            new ParamInfo { Name = "p", Description = "Prawdopodobieństwo globalnej eksploracji", LowerBoundary = 0.1, UpperBoundary = 1.0, IsInteger = false },
            new ParamInfo { Name = "pop", Description = "Wielkość populacji", LowerBoundary = 10, UpperBoundary = 150, IsInteger = true },
            new ParamInfo { Name = "itr", Description = "Liczba iteracji", LowerBoundary = 5, UpperBoundary = 100, IsInteger = true }
        };

        public IStateWriter writer { get; set; } = new StateWriter();
        public IStateReader reader { get; set; } = new StateReader();
        public IGenerateTextReport stringReportGenerator { get; set; }
        public IGeneratePDFReport pdfReportGenerator { get; set; } = new PDFReportGenerator();

        public double[] XBest { get; set; }
        public double FBest { get; set; }

        private double[,] population;
        private double[] Ii; // Intensywność zapachu
        private double[] Fi; // Zapach (fragrance)
        private double a;
        private double c;
        private double p;
        private int populationSize;
        private int dimensions;
        private int iterations;
        private Func<double[], double> fitnessFunction;
        public TestData data { get; set; }

        public string getJson()
        {
            return JsonSerializer.Serialize<TestData>(data);
        }
        public void setJson(TestData d)
        {
            data = d;
            data.resIn = new double[(int)(iterations / 5)];
        }

        public void setFuncName(string name)
        {
            data.func = name;

        }

        public static double[][] ConvertToJaggedArray(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            double[][] jaggedArray = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = array[i, j];
                }
            }

            return jaggedArray;
        }

        public void Solve_restart(int i, double[,] pop,double f, double[] x)
        {
            data.state = "RUN";
            population = pop;
            FBest = f;
            XBest = x;
            for (int iter = i; iter < iterations; iter++)
            {
                CalculateIntensities();
                CalculateFragrance();
                FindBest();
                UpdatePositions();

                // Zapis stanu co kilka iteracji
                if (iter % 10 == 0)
                {
                    data.population = ConvertToJaggedArray(population);
                    data.XBest = XBest;
                    data.FBest = FBest;
                    data.curIter = iter;
                    string jsonString = JsonSerializer.Serialize(data);
                    File.WriteAllText("test_.json", jsonString);
                    File.Copy("test_.json", "test.json", true);
                }
                if (iter % 5 == 0)
                {
                    data.resIn[iter / 5] = FBest;
                }

            }
            File.Delete("test.json");
            File.Delete("test_.json");
            data.state = "DONE";
            data.FBest = FBest;
            data.XBest = XBest;
        }


        public void init(Func<double[], double> f, double[,] domain, params double[] parameters)
        {
            // Przypisanie parametrów
            fitnessFunction = f;
            a = parameters[0];
            c = parameters[1];
            p = parameters[2];
            dimensions = domain.GetLength(0);
            populationSize = (int)parameters[3];
            iterations = (int)parameters[4];
            data = new TestData();
            data.name = Name;
            data.param1 = a;
            data.param2 = c;
            data.param3 = p;
            data.iter = iterations;
            data.dim = dimensions;
            data.resIn = new double[(int)(iterations / 5)];
            data.limits = ConvertToJaggedArray(domain);
            data.popSize = populationSize;

            Console.WriteLine("Rozpoczynam BOA...");
            InitializePopulation(domain);
        }


        public void setPopNull()
        {
            data.population = null;
        }

        public void Solve()
        {

            data.state = "RUN";
            for (int iter = 0; iter < iterations; iter++)
            {
                CalculateIntensities();
                CalculateFragrance();
                FindBest();
                UpdatePositions();

                // Zapis stanu co kilka iteracji
                if (iter % 10 == 0)
                {
                    data.population = ConvertToJaggedArray(population);
                    data.XBest = XBest;
                    data.FBest = FBest;
                    data.curIter = iter;
                    string jsonString = JsonSerializer.Serialize(data);
                    File.WriteAllText("test_.json", jsonString);
                    File.Copy("test_.json", "test.json", true);
                }
                if (iter % 5 == 0)
                {
                    data.resIn[iter / 5] = FBest;
                }

            }
            File.Delete("test.json");
            File.Delete("test_.json");
            data.state = "DONE";
            data.FBest = FBest;
            data.XBest = XBest;

            Console.WriteLine($"Najlepsze rozwiązanie: f(X) = {FBest}, X = [{string.Join(", ", XBest)}]");
            Console.WriteLine($"a = {a}, c = {c},p = {p}");
            PDFReportGenerator pDFReportGenerator = new PDFReportGenerator();
            pDFReportGenerator.raportData(data);
            pDFReportGenerator.GenerateReport("Rapor_" + data.func + ".pdf");
        }

        private void InitializePopulation(double[,] domain)
        {
            Random rand = new Random();
            population = new double[populationSize, dimensions];
            Ii = new double[populationSize];
            Fi = new double[populationSize];

            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    population[i, j] = rand.NextDouble() * (domain[j, 1] - domain[j, 0]) + domain[j, 0];
                }
            }
        }

        private void CalculateIntensities()
        {
            for (int i = 0; i < populationSize; i++)
            {
                double[] individual = GetIndividual(population, i);
                Ii[i] = fitnessFunction(individual);
            }
        }

        private void CalculateFragrance()
        {
            for (int i = 0; i < populationSize; i++)
            {
                Fi[i] = c * Math.Pow(Ii[i], a);
            }
        }

        private void FindBest()
        {
            FBest = Ii[0];
            XBest = GetIndividual(population, 0);

            for (int i = 1; i < populationSize; i++)
            {
                if (Ii[i] < FBest)
                {
                    FBest = Ii[i];
                    XBest = GetIndividual(population, i);
                }
            }
        }

        private void UpdatePositions()
        {
            Random rand = new Random();
            for (int i = 0; i < populationSize; i++)
            {
                double r = rand.NextDouble();
                double[] newPos = new double[dimensions];

                if (r < p)
                {
                    for (int j = 0; j < dimensions; j++)
                    {
                        newPos[j] = population[i, j] + Math.Pow(r, 2) * (XBest[j] - population[i, j]) * Fi[i];
                    }
                }
                else
                {
                    int randomButterfly = rand.Next(populationSize);
                    for (int j = 0; j < dimensions; j++)
                    {
                        newPos[j] = population[i, j] + Math.Pow(r, 2) * (population[randomButterfly, j] - population[i, j]) * Fi[i];
                    }
                }

                if (fitnessFunction(newPos) < Ii[i])
                {
                    for (int j = 0; j < dimensions; j++)
                    {
                        population[i, j] = newPos[j];
                    }
                }
            }
        }

        private double[] GetIndividual(double[,] population, int index)
        {
            double[] individual = new double[dimensions];
            for (int j = 0; j < dimensions; j++)
            {
                individual[j] = population[index, j];
            }
            return individual;
        }
    }
}
