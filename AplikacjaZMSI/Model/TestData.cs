using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI.Model
{
    public class TestData
    {
        public string state { get; set; } = "TOGO";
        public string name { get; set; } = "";
        public string func { get; set; } = "";
        public double param1 { get; set; } = 0.0;
        public double param2 { get; set; } = 0.0;
        public double param3 { get; set; } = 0.0;
        public double FBest { get; set; }  = 0.0;
        public double[] XBest { get; set; }
        public int popSize { get; set; } = 0;
        public int dim { get; set; } = 0;
        public int iter { get; set; } = 0;
        public double[][] population { get; set; }
        public double[,] limits { get; set; }
        public int curIter { get; set; } = 0;
    }
}
