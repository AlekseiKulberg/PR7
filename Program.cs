using System;

namespace Pr7
{
    internal class Program
    {
        //Random 2D array generation
        static double[][] GenRanomArray(int w, int h)
        {
            if (w <= 0 || h <= 0)
                throw (new Exception("Invalid array size"));

            Random rnd = new Random();

            double[][] randomArray = new double[w][];
            for (int i = 0; i < w; ++i)
            {
                randomArray[i] = new double[h];
                for (int j = 0; j < h; ++j)
                    randomArray[i][j] = Math.Round((rnd.NextDouble() * (2 - 13) + 10), 3);
            }
            return randomArray;
        }



        static void Main(string[] args)
        {
            double[][] array_test = GenRanomArray(10, 10);

            for (int i = 0; i < array_test.Length; ++i)
            {
                for (int j = 0; j < array_test[i].Length; ++j)
                {
                    Console.Write($"{array_test[i][j]}\t");
                }
                Console.WriteLine("");
            }
        }
    }
}