using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WE01Lib
{
    public class Maand
    {
        private int maandnr;

        public int Maandnr
        {
            get { return maandnr; }
            set
            {
                if (value >= 1 && value <= 12)
                {
                    maandnr = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(maandnr), "Maandnr moet een nummer zijn tussen 1 en 12 inclusief.");
                }
            }
        }

        private int jaar;

        public int Jaar
        {
            get { return jaar; }
            set
            {
                if (value >= DateTime.MinValue.Year && value <= DateTime.MaxValue.Year)
                {
                    jaar = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(jaar), $"Jaar moet een nummer zijn tussen {DateTime.MinValue.Year} en {DateTime.MaxValue.Year} inclusief."); ;
                }
            }
        }


        private readonly Dictionary<int, List<string>> data;

        public Maand()
        {
            // voor elke dag in de week een lijn in de dictionary klaarzetten met een lege lijst van strings
            data = new Dictionary<int, List<string>>();

            foreach (DayOfWeek dag in Enum.GetValues(typeof(DayOfWeek)))
            {
                // in Amerika begint de week op zondag (= 0),
                // daarom kleine omzetting: zondag wordt 6 en alle andere dagen worden -1 gedaan
                // waardoor maandag = 0 (i.p.v. 1), dinsdag = 1 (i.p.v. 2), ...
                if (dag == DayOfWeek.Sunday)
                {
                    data.Add(6, new List<string>());
                }
                else
                {
                    // enums hebben achterliggen een int-waarde, dus je kan zonder problemen casten
                    data.Add((int)dag - 1, new List<string>());
                }
            }
        }

        public override string ToString()
        {
            DateTime datum = new(Jaar, Maandnr, 1);
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(datum.ToString("Y"));
            stringBuilder.AppendLine();

            // omzetten weekdag (uitleg zie ctor)
            int weekdag = (datum.DayOfWeek == DayOfWeek.Sunday) ? 6 : (int)datum.DayOfWeek - 1;

            for (int i = 0; i < weekdag; i++)
            {
                // maand begint niet op maandag, dus lege plaatsen invoegen op dagen vóór de begindag van de maand
                if (data.TryGetValue(i, out List<string>? dd))
                {
                    dd.Add(string.Empty);
                }
            }

            // elke dag in deze maand aflopen            
            while (datum.Month == Maandnr)
            {
                weekdag = (datum.DayOfWeek == DayOfWeek.Sunday) ? 6 : (int)datum.DayOfWeek - 1;
                // alle dagen voor deze weekdag opvragen & huidige dag toevoegen
                if (data.TryGetValue(weekdag, out List<string>? dd))
                {
                    dd.Add(datum.ToString("dd"));
                }
                datum = datum.AddDays(1);
            }

            // "kalender" opbouwen met stringbuilder
            stringBuilder.AppendLine("ma\t" + string.Join("\t", data[0]));
            stringBuilder.AppendLine("di\t" + string.Join("\t", data[1]));
            stringBuilder.AppendLine("wo\t" + string.Join("\t", data[2]));
            stringBuilder.AppendLine("do\t" + string.Join("\t", data[3]));
            stringBuilder.AppendLine("vr\t" + string.Join("\t", data[4]));
            stringBuilder.AppendLine("za\t" + string.Join("\t", data[5]));
            stringBuilder.AppendLine("zo\t" + string.Join("\t", data[6]));

            return stringBuilder.ToString();
        }
    }
}

