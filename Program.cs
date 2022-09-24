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

        //Выполнение задания №1
        #region TASK1

        static Dictionary<int, double> GetSumIfContainsNegative(double[][] array)
        {
            Func<double[], double> getArraySum = str =>
            {
                double sum = 0;
                for (int i = 0; i < str.Length; ++i)
                    sum += str[i];
                return sum;
            };

            Dictionary<int, double> result = new Dictionary<int, double>();

            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i].Any(n => n < 0))
                    result.Add(i, getArraySum(array[i]));
            }
            return result;
        }

        //w = array width, h = array height
        static void Task1Check(int w, int h)
        {
            double[][] array_1 = GenRanomArray(w, h);
            Dictionary<int, double> array1_sums = GetSumIfContainsNegative(array_1);

           
            Console.WriteLine("****[TASK1]****\n");
            Console.WriteLine("Plain array:");
            for (int i = 0; i < array_1.Length; ++i)
            {
                for (int j = 0; j < array_1[i].Length; ++j)
                {
                    Console.Write($"{array_1[i][j]}\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\nResult:");
            for (int i = 0; i < array1_sums.Count; ++i)
            {
                var LineSum = array1_sums.ToList()[i];
                Console.WriteLine($"Line: \"{LineSum.Key}\"\t Sum: \"{LineSum.Value}\"");
            }
        }
        #endregion //TASK1

        static void Main(string[] args)
        {
            Task1Check(20, 10);
        }
    }
}