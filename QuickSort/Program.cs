using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {


        private static int[] Combine(int[] array1, int[] array2, int[] array3)
        {
            var x = array1.Concat(array2).Concat(array3);
            return x.ToArray();

        }

        static int n = 0;
        private static int[] QuickSortAlgorithm(int[] array)
        {
            if (array.Length < 2)
                return array;
            else
            {
                int pivotIndex = (array.Length / 2) -1;
                int pivot = array[pivotIndex];
                List<int> less = new List<int>();
                List<int> greater = new List<int>();

                for (int i = 0; i < array.Length; i++)
                {
                    n++;
                    if(i != pivotIndex)
                    {
                        if (array[i] <= pivot)
                        {
                            less.Add(array[i]);
                        }
                        else
                        {
                            greater.Add(array[i]);
                        }
                    }
 
                }

                return Combine(QuickSortAlgorithm(less.ToArray()), new int[1] { pivot }, QuickSortAlgorithm(greater.ToArray()));
            }
        }
        static void Main(string[] args)
        {
            //int[] array = new int[8] { 20, 5, 3, 5, 10, 6, 8 , 2 };
            int Min = 0;
            int Max = 2000;
            Random randNum = new Random();
            int[] array = Enumerable
                .Repeat(0, Max)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();

            var sortedArray = QuickSortAlgorithm(array);
            sortedArray.ToList().ForEach(i => Console.WriteLine(i.ToString()));
            Console.WriteLine("Tries: " + n.ToString());
            Console.ReadLine();
        }
    }
}
