using System.Globalization;
using System.Text;

namespace WE01Lib
{
    public class Maand
    {
        private static readonly string[] DagNamen = ["ma", "di", "wo", "do", "vr", "za", "zo"];

        public int Maandnr
        {
            get;
            set
            {
                if (value >= 1 && value <= 12)
                {
                    field = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Maandnr), "Maandnr moet een nummer zijn tussen 1 en 12 inclusief.");
                }
            }
        } = DateTime.Today.Month;

        public int Jaar
        {
            get;
            set
            {
                if (value >= DateTime.MinValue.Year && value <= DateTime.MaxValue.Year)
                {
                    field = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Jaar), $"Jaar moet een nummer zijn tussen {DateTime.MinValue.Year} en {DateTime.MaxValue.Year} inclusief."); ;
                }
            }
        } = DateTime.Today.Year;

        public override string ToString()
        {
            DateTime datum = new(Jaar, Maandnr, 1);
            int aantalDagen = DateTime.DaysInMonth(Jaar, Maandnr);

            // Op welke dag startte deze maand

            // in Amerika begint de week op zondag (= 0),
            // daarom kleine omzetting: zondag wordt 6 en alle andere dagen worden -1 gedaan
            // waardoor maandag = 0 (i.p.v. 1), dinsdag = 1 (i.p.v. 2), ..., zondag = 6                    
            int startDag = ((int)datum.DayOfWeek + 6) % 7; // enums hebben achterliggen een int-waarde, dus je kan zonder problemen casten

            // aantal weken in die maand, afgerond naar boven
            int aantalWeken = (int)Math.Ceiling((startDag + aantalDagen) / 7m);

            // 2-dim array: een rij voor elke weekdag en een kolom voor elke week
            string[,] kalender = new string[7, aantalWeken];

            // array opvullen (for vanaf 1, want er is geen dag 0 in de maand)
            for (int dagnr = 1; dagnr <= aantalDagen; dagnr++)
            {
                int index = startDag + dagnr - 1;
                int rij = index % 7;
                int kol = index / 7;

                kalender[rij, kol] = dagnr.ToString("00");
            }

            // StringBuilder om uitvoer op te bouwen
            StringBuilder sb = new();
            sb.AppendLine(datum.ToString("Y", CultureInfo.CurrentCulture));
            sb.AppendLine();

            // per rij naam van de dag toevoegen gevolgd door de kolommen, gescheiden door een tab
            for (int rij = 0; rij < 7; rij++)
            {
                sb.Append(DagNamen[rij]);

                for (int col = 0; col < aantalWeken; col++)
                {
                    sb.Append('\t');
                    sb.Append(kalender[rij, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

