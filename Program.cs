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


        #region TASK2

        static void SwapArrayLines(ref double[][] array, int index_from, int index_to)
        {
            if (index_from == index_to)
                return;

            for (int i = 0; i < array[0].Length; ++i)
                (array[index_from][i], array[index_to][i]) = (array[index_to][i], array[index_from][i]);
        }

        static void SwapArrayColumns(ref double[][] array, int index_from, int index_to)
        {
            if (index_from == index_to)
                return;

            for (int i = 0; i < array.Length; ++i)
                (array[i][index_from], array[i][index_to]) = (array[i][index_to], array[i][index_from]);
        }
        public class ArrayValue<T>
        {
            public ArrayValue(int i, int j, T value)
            {
                this.I = i;
                this.J = j;
                this.Value = value;
            }

            public int I { get; set; }
            public int J { get; set; }
            public T Value { get; set; }
        };

        static ArrayValue<double> getArrayHighestElement(double[][] array)
        {
            ArrayValue<double> result = new ArrayValue<double>(0, 0, 0);
            double max = double.MinValue;
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                {
                    if (Math.Abs(array[i][j]) > max)
                    {
                        max = Math.Abs(array[i][j]);
                        result.I = i;
                        result.J = j;
                        result.Value = Math.Abs(array[i][j]);
                    }
                }
            }
            return result;
        }
        static void MoveHighestElement(ref double[][] array, int i, int j)
        {
            ArrayValue<double> target_value = getArrayHighestElement(array);
            SwapArrayLines(ref array, target_value.I, i);
            SwapArrayColumns(ref array, target_value.J, j);
        }

        static void Task2Check(int width, int height, int to_x, int to_y)
        {
            Console.WriteLine("Plain array:\n");
            double[][] array = GenRanomArray(width, height);
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                {
                    Console.Write($"{array[i][j]}\t");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine($"Highest element coordinates:\t\t[{getArrayHighestElement(array).I}, {getArrayHighestElement(array).J}]");
            Console.WriteLine($"Highest element value:\t\t\t{getArrayHighestElement(array).Value}");
            Console.WriteLine($"Highest element will be moved to:\t[{to_x}, {to_y}]");
            Console.WriteLine("");


            MoveHighestElement(ref array, to_x, to_y);


            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                {
                    Console.Write($"{array[i][j]}\t");
                }
                Console.WriteLine("");
            }
        }

        #endregion

        static void Main(string[] args)
        {
            Task1Check(20, 10);
            Task2Check(20, 10, 1, 1);
        }
    }
}