using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading.Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = 2;
            int numTwo = 3;

            int res = Sum(numOne, numTwo);
            Console.WriteLine($"Sum(int n1, int n2) => {res}");
            Console.WriteLine();

            // By changing the number of parameters in a method
            int[] nums = new int[] { 1, 3, 5 };
            int resNumParams = Sum(nums);
            Console.WriteLine($"Sum(int[] numbers) => {resNumParams}");
            Console.WriteLine();

            // By using different data types for parameters
            double diffType = 5.35;
            int resDiffType = Sum(diffType, numOne);
            Console.WriteLine($"Sum(double n1, int n2) => {resDiffType}"); // 7
            Console.WriteLine();

            // By changing the order of parameters in a method
            int resDiffOrder = Sum(numOne, diffType);
            Console.WriteLine($"Sum(int n1, double n2) => {resDiffOrder}"); // 7

            Console.ReadKey();
        }

        public static int Sum(int n1, int n2) => n1 + n2;

        // By changing the number of parameters in a method
        public static int Sum(int[] numbers) => numbers.Sum();

        // By using different data types for parameters
        public static int Sum(double n1, int n2) => (int)(n1 + n2);

        // By changing the order of parameters in a method
        public static int Sum(int n1, double n2) => (int)(n1 + n2);

        #region WILL NOT COMPILE

        // Note that we can't change the order of two parameters of the same datatype.
        // public static int Sum(int n2, int n1) => n1 + n2;

        // Note that only changing the return type won't work. Look at the example below.
        // public static double Sum(int n1, n2) =>	n1 + n2;

        #endregion
    }
}
