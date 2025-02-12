﻿using System;
using System.Linq;
using System.Text.Json.Serialization;
using MathNet.Numerics;
using System.IO;
using System.Text.Json;

namespace AplikacjaZMSI.Model
{
    public class AquilaOptimizer : IOptimizationAlgorithm
    {
        public string Name { get; set; } = "Aquila Optimizer (AO)";
        public ParamInfo[] ParamsInfo { get; set; } = new ParamInfo[]
        {
            new ParamInfo { Name = "alpha", Description = "Parametr alpha", LowerBoundary = 0.1, UpperBoundary = 1.0, IsInteger = false },
            new ParamInfo { Name = "delta", Description = "Parametr delta", LowerBoundary = 0.1, UpperBoundary = 2.0, IsInteger = false },
            new ParamInfo { Name = "beta", Description = "Parametr beta (dla dystrybucji Lévy'ego)", LowerBoundary = 1.0, UpperBoundary = 3.0, IsInteger = false },
            new ParamInfo { Name = "pop", Description = "Wielkość populacji", LowerBoundary = 10, UpperBoundary = 150, IsInteger = true },
            new ParamInfo { Name = "itr", Description = "Liczba iteracji", LowerBoundary = 5, UpperBoundary = 100, IsInteger = true }
        };
        public IStateWriter writer { get; set; } = new StateWriter();
        public IStateReader reader { get; set; } = new StateReader();
        public IGenerateTextReport stringReportGenerator { get; set; }
        public IGeneratePDFReport pdfReportGenerator { get; set; } = new PDFReportGenerator();

        public double[] XBest { get; set; }
        public double FBest { get; set; }
        private double[][] population;
        private double[][] limits;
        private double delta;        
        private double beta;
        private double alpha;
        private int populationSize;
        private int dimensions;
        private int iterations;
        private Func<double[], double> fitnessFunction;
        private Random rand = new Random();
        public TestData data { get; set; }

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


        public void init(Func<double[], double> f, double[,] domain, params double[] parameters)
        {
            // Przypisanie parametrów
            fitnessFunction = f;
            alpha = parameters[0];
            delta = parameters[1];
            beta = parameters[2];
            dimensions = domain.GetLength(0);
            populationSize = (int)parameters[3];
            iterations = (int)parameters[4];
            data = new TestData();
            data.name = Name;
            data.param1 = alpha;
            data.param2 = delta;
            data.param3 = beta;
            data.iter = iterations;
            data.dim = dimensions;
            data.resIn = new double[(int)(iterations / 5)];
            data.limits = ConvertToJaggedArray(domain);
            data.popSize = populationSize;

            Console.WriteLine("Rozpoczynam Aquila Optimizer...");
            InitializePopulation(domain);
        }

        public string getJson()
        {
            return  JsonSerializer.Serialize<TestData>(data);
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

        public void setPopNull()
        {
            data.population = null; 
        }

        public void Solve_restart(int i, double[,] pop, double f, double[] x)
        {
            data.state = "RUN";
            population = ConvertToJaggedArray(pop);
            FBest = f;
            XBest = x;
            for (int iter = i; iter < iterations; iter++)
            {
                FindBest();
                UpdatePositions(iter);

                // Zapis stanu co kilka iteracji
                if (iter % 10 == 0)
                {
                    data.population = population;
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

        public void Solve()
        {
            

            for (int iter = 0; iter < iterations; iter++)
            {
                data.state = "RUN";
                FindBest();
                UpdatePositions(iter);
                // Zapis stanu co kilka iteracji
                if (iter % 10 == 0)
                {
                    data.population = population;
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
            data.state = "DONE";
            data.FBest = FBest;
            data.XBest = XBest;
            File.Delete("test.json");
            File.Delete("test_.json");

            Console.WriteLine($"Najlepsze rozwiązanie: f(X) = {FBest}, X = [{string.Join(", ", XBest)}]");
            PDFReportGenerator pDFReportGenerator = new PDFReportGenerator();
            pDFReportGenerator.raportData(data);
            pDFReportGenerator.GenerateReport("Rapor_"+data.func+".pdf");
        }

        private void InitializePopulation(double[,] domain)
        {
            population = new double[populationSize][];
            limits = new double[dimensions][];

            for (int i = 0; i < dimensions; i++)
            {
                limits[i] = new double[] { domain[i, 0], domain[i, 1] };
            }

            for (int i = 0; i < populationSize; i++)
            {
                population[i] = new double[dimensions];
                for (int j = 0; j < dimensions; j++)
                {
                    population[i][j] = rand.NextDouble() * (limits[j][1] - limits[j][0]) + limits[j][0];
                }
            }
        }

        private void FindBest()
        {
            FBest = fitnessFunction(population[0]);
            XBest = population[0].Clone() as double[];

            for (int i = 1; i < populationSize; i++)
            {
                double fitness = fitnessFunction(population[i]);
                if (fitness < FBest)
                {
                    FBest = fitness;
                    XBest = population[i].Clone() as double[];
                }
            }
        }

        private double[] LevyFlight(int dim)
        {
            double sigma = Math.Pow(
                (SpecialFunctions.Gamma(1 + beta) * Math.Sin(Math.PI * beta / 2))
                / (SpecialFunctions.Gamma((1 + beta) / 2) * beta * Math.Pow(2, (beta - 1) / 2)),
                1 / beta);

            double[] u = Enumerable.Range(0, dim).Select(_ => rand.NextDouble() * sigma).ToArray();
            double[] v = Enumerable.Range(0, dim).Select(_ => rand.NextDouble()).ToArray();

            return u.Zip(v, (ui, vi) => ui / Math.Pow(Math.Abs(vi), 1 / beta)).ToArray();
        }

        private void UpdatePositions(int iteration)
        {
            double g1 = 2 * (1 - (double)iteration / iterations); // Dynamiczny współczynnik
            double g2 = 2 * rand.NextDouble() - 1;

            for (int i = 0; i < populationSize; i++)
            {
                double[] newPosition = new double[dimensions];

                if (iteration < iterations * 2 / 3) // Eksploracja
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        newPosition = XBest.Select((xi, j) => xi * (1 - (double)iteration / iterations) +
                            (population[i].Average() - xi) * rand.NextDouble()).ToArray();
                    }
                    else
                    {
                        double[] levyStep = LevyFlight(dimensions);
                        newPosition = XBest.Zip(levyStep, (xi, li) => xi + li).ToArray();
                    }
                }
                else // Eksploatacja
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        newPosition = limits.Zip(XBest, (limit, xi) =>
                            (xi - population[i].Average()) * alpha - rand.NextDouble() +
                            ((limit[1] - limit[0]) * rand.NextDouble() - limit[0]) * delta).ToArray();
                    }
                    else
                    {
                        newPosition = XBest.Select(xi => xi * g1 + g2 * rand.NextDouble()).ToArray();
                    }
                }

                // Aktualizacja populacji
                if (fitnessFunction(newPosition) < fitnessFunction(population[i]))
                {
                    population[i] = newPosition;
                }
            }
        }
    }
}
