using System;
using WE01Lib;

namespace WE01
{
    class Program
    {
        static void Main(string[] args)
        {
            Oef1();
        }

        private static void Oef1()
        {
            int a = 17; // the least random number
            int b = 47; // the quintessential random number

            Console.WriteLine($"Voor wissel: a = {a}, b = {b}");            

            Helper.Wissel(ref a, ref b);

            Console.WriteLine($"Na wissel: a = {a}, b = {b}");
        }
    }
}
