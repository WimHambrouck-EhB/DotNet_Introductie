using System;
using System.Text;
using WE01Lib;

namespace WE01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Oef 1: Wissel =====");

            int a = 17; // the least random number
            int b = 47; // the quintessential random number
            Console.WriteLine("Waarden voor wissel:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");

            Helper.Wissel(ref a, ref b);

            Console.WriteLine("Na wissel:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine();

            Console.WriteLine("===== Oef 2: camelCase =====");
            Console.Write("Voer een zin in: ");
            string? invoer = Console.ReadLine();

            // blijven invoer vragen als invoer leeg was
            while (string.IsNullOrWhiteSpace(invoer))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldige invoer!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.Write("Voer een zin in: ");
                invoer = Console.ReadLine();
            }

            Console.WriteLine(Helper.ZinNaarCamelCase(invoer));
            Console.WriteLine();

            Console.WriteLine("===== Oef 3: Kalender =====");

            Maand currentMonth = new();
            currentMonth.Maandnr = 11;
            currentMonth.Jaar = 2002;
            Console.WriteLine(currentMonth);
        }
    }
}
