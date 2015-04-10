using System;

namespace Matrices.ConsoleTest
{
    class Program
    {
        static void Main()
        {
            var a9Q4 = new Matrix(8, 8, new[,]
            {
                {10, 1.6, 1.4, .5, 1.2, 1.5, 1.8, 2.3},
                {1.6, 10, .9, 1.8, 1.2, 2.6, 2.3, 1.1},
                {1.4, .9, 10, 2.5, 1.7, 2.5, 1.9, 1},
                {.5, 1.8, 2.5, 10, .7, 1.6, 1.5, .9},
                {1.2, 1.2, 1.7, .7, 10, .9, 1.1, .8},
                {1.5, 2.6, 2.5, 1.6, .9, 10, .6, 1},
                {1.8, 2.3, 1.9, 1.5, 1.1, .6, 10, .5},
                {2.3, 1.1, 1,    .9,  .8 , 1, .5, 10}
            });
            var res = MatrixOps.ShortestPath(a9Q4, 1);
            var total = 0.0;
            foreach (var p in res)
            {
                Console.WriteLine((p.Key[0]+1) + "/" + (p.Key[1]+1) + ": " + p.Value);
                total += p.Value;
            }
            Console.WriteLine("Total: " + total);
        }
    }
}