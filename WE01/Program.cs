using System;
using System.Text;
using WE01Lib;

namespace WE01
{
    class Program
    {
        static void Main(string[] args)
        {
            Oef3();
        }

        private static void Oef1()
        {
            int a = 17; // the least random number
            int b = 47; // the quintessential random number

            Console.WriteLine($"Voor wissel: a = {a}, b = {b}");            

            Helper.Wissel(ref a, ref b);

            Console.WriteLine($"Na wissel: a = {a}, b = {b}");
        }

        private static void Oef2()
        {
            Console.Write("Zin: ");
            string invoer = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(invoer))
            {
                Console.WriteLine("Ongeldige invoer! Probeer opnieuw...");
                Console.Write("Zin: ");
                invoer = Console.ReadLine();
            }

            string[] woorden = invoer.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();
            builder.Append(woorden[0].ToLower());

            for (int i = 1; i < woorden.Length; i++)
            {
                builder.AppendFormat("{0}{1}", woorden[i].Substring(0, 1).ToUpper(), woorden[i].Substring(1).ToLower());
            }

            Console.WriteLine(builder.ToString());
        }


        private static void Oef3()
        {
            Maand currentMonth = new Maand();
            currentMonth.MaandNr = 11;
            currentMonth.Jaar = 2002;
            Console.WriteLine(currentMonth);
        }
    }
}
