using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WE01Lib
{
    public class Maand
    {
        public int MaandNr { get; set; }
        public int Jaar { get; set; }

        private int[][] dagen; // jagged array = array die 

        public Maand()
        {
            dagen = new int[7][];
            dagen[0] = new int[5];
            dagen[1] = new int[5];
            dagen[2] = new int[5];
            dagen[3] = new int[5];
            dagen[4] = new int[5];
            dagen[5] = new int[5];
            dagen[6] = new int[5];            
        }

        public override string ToString()
        {
            DateTime dateTime = new DateTime(Jaar, MaandNr, 1);
            StringBuilder stringBuilder = new StringBuilder();
            // CultureInfo zorgt voor uniforme uitvoer volgens taalconventies van gespecifieerde Culture. CultureInfo parameter kan worden weggelaten, in dat geval wordt gekeken naar de syteemtaal van de gebruiker
            stringBuilder.AppendLine(dateTime.ToString("MMMM yyyy", new CultureInfo("nl-BE")));

            stringBuilder.AppendLine("$ma\t");

            for (int i = 0; i < dagen.Length; i++)
            {
                Console.Write(WeekDayFromInt(i) + "\t");
                for (int j = 0; j < dagen[i].Length; j++)
                {
                    Console.Write("00\t");
                }
                Console.WriteLine("");
            }


            return stringBuilder.ToString();
        }

        private static string WeekDayFromInt(int day)
        {
            // verkorte schrijfwijze voor switch als alle code paths enkel een return doen
            return day switch
            {
                0 => "ma",
                1 => "di",
                2 => "wo",
                3 => "do",
                4 => "vr",
                5 => "za",
                6 => "zo",
                _ => "",
            };
        }
    }
}

