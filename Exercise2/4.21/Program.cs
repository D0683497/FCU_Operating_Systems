using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _4._21
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = GetInput();

            Thread thr1 = new Thread(GetAverage);
            Thread thr2 = new Thread(GetMinimum);
            Thread thr3 = new Thread(GetMaximum);

            thr1.Start(list);
            thr2.Start(list);
            thr3.Start(list);

            thr1.Join();
            thr2.Join();
            thr3.Join();

            Console.WriteLine("按任意鍵關閉此視窗");
            Console.ReadKey();
        }

        private static void GetAverage(object obj)
        {
            var list = (IEnumerable<int>)obj;
            Console.WriteLine($"The average value is {(int)list.Average()}");
        }

        private static void GetMinimum(object obj)
        {
            var list = (IEnumerable<int>)obj;
            Console.WriteLine($"The minimum value is {list.Min()}");
        }

        private static void GetMaximum(object obj)
        {
            var list = (IEnumerable<int>)obj;
            Console.WriteLine($"The maximum value is {list.Max()}");
        }

        public static IEnumerable<int> GetInput()
        {
            Console.Write("請輸入: ");
            string input = Console.ReadLine();
            string[] intlist = input.Split(new char[] { ',', ' ' });
            List<int> resultList = new List<int>();

            foreach (string item in intlist)
            {
                try
                {
                    int result = Int32.Parse(item);
                    resultList.Add(result);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{item}'");
                }
            }

            return resultList;
        }
    }
}
