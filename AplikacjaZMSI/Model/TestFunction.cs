using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI.Model
{
    public class TestFunction
    {
        public static double Sphere(double[] xi)
        {
            double ret = 0;
            foreach (double x in xi)
            {
                ret += Math.Pow(x, 2);
            }
            return ret;
        }

        public static double Rastrigin(double[] xi)
        {
            double ret = 0;
            foreach (double x in xi)
            {
                ret += (Math.Pow(x, 2) - 10 * Math.Cos(2 * Math.PI * x) + 10);
            }
            return ret;
        }

        public static double Rosenbrock(double[] xi)
        {
            return Math.Pow((1.5 - xi[0] + xi[0] * xi[1]), 2) + Math.Pow((2.25 - xi[0] + xi[0] * Math.Pow(xi[1], 2)), 2) +
                Math.Pow((2.625 - xi[0] + xi[0] * Math.Pow(xi[1], 3)), 2);
        }

        public static double Beale(double[] xi)
        {
            double ret = 0;
            for (int i = 0; i < xi.Length - 1; i++)
            {
                ret += (100 * Math.Pow(xi[i + 1] - Math.Pow(xi[i], 2), 2) + Math.Pow(xi[i] - 1, 2));
            }
            return ret;
        }
    }
}
