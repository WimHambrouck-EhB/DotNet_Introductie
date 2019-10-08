using System;

namespace WE01Lib
{
    public static class Helper
    {
        /// <summary>
        /// Wisselt twee integer waarden met elkaar om.
        /// </summary>
        /// <param name="a">Eerste waarde, wordt verwisseld met <paramref name="b"/></param>
        /// <param name="b">Tweede waarde, wordt verwisseld met <paramref name="a"/></param>
        public static void Wissel(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
