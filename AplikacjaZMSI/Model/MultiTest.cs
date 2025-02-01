using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI.Model
{
    public class MultiTest
    {
        private Func<int, bool> progres;
        private List<IOptimizationAlgorithm> testList;
        public MultiTest(Func<int,bool> pr)
        {
            testList = new List<IOptimizationAlgorithm>();
            progres = pr;
            progres.Invoke(0);
        }
        public void run(string testFunc, List<string> algoritms )
        {
            createTests(algoritms);
            int i = 0;
            foreach (var test in testList)
            {
                test.Solve(testFunc);
                i++;
                progres.Invoke(i/testList.Count*100);
            }
            //for
            //test
            // prog update

        }

        private void createTests( List<string> algoritms)
        {
            foreach (var alg in algoritms)
            {
                if(alg == "AO")
                {
                    testList.Add(new AquilaOptimizer());
                }
                else if(alg == "BOA")
                {
                    testList.Add(new BOAAlgorithm());
                }
            }  
        }

    }
}
