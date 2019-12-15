using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT_solver
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[,] pb = new string[2, 2] { { "a", "b" }, { "a", "-c" } };
            string[,] pb = new string[3, 2] { { "a", "b" }, { "a", "-b" }, { "-a", "-b" } };
            //string[,] pb = new string[2, 3] { { "v1","-v2","v3" }, { "-v1", "v3","v4" } };
            //string[,] pb = new string[4, 2] { { "a", "b" }, { "-a", "b" }, { "a", "-b" }, { "-a", "-b" } };
            //string[,] pb = new string[8, 3] { { "a", "b" ,"c"}, { "-a", "b","c" }, { "a", "-b", "c" }, { "-a", "-b", "c" },{ "a", "b" ,"-c"}, { "-a", "b","-c" }, { "a", "-b", "-c" }, { "-a", "-b", "-c" } };
            //string[,] pb = new string[2, 2] { { "-v1", "-v1" }, { "v1", "v1" }};
            Solver s = new Solver(pb);
        }
    }
}
