using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class DateTimeGenerator
    {

        static DateTimeGenerator()
        {
            rand = new Random();
        }
        public static Random rand;

        /// <summary>
        /// Generates a random date time between 0001-01-01T00:00:00.000Z and 9999-12-31T23:59:59.999Z
        /// </summary>
        /// <returns>Random datetime object</returns>
        public static DateTime Generate()
        {
            int year = rand.Next(1, 9999);
            int month = rand.Next(1, 12);
            int day = GetRandomMonthDay(month);

            int hour = rand.Next(0, 23);
            int minutes = rand.Next(0, 59);
            int seconds = rand.Next(0, 59);
            int miliseconds = rand.Next(0, 999);

            return new DateTime(year, month, day, hour, minutes, seconds, miliseconds, DateTimeKind.Utc);
        }

        static int GetRandomMonthDay(int month)
        {
            switch (month)
            {
                case 1: return rand.Next(1, 31); // January
                case 2: return rand.Next(1, 28); // Feberuary
                case 3: return rand.Next(1, 31); // March
                case 4: return rand.Next(1, 30); // April
                case 5: return rand.Next(1, 31); // May
                case 6: return rand.Next(1, 30); // June
                case 7: return rand.Next(1, 31); // July
                case 8: return rand.Next(1, 31); // August
                case 9: return rand.Next(1, 30); // September
                case 10: return rand.Next(1, 31); // October
                case 11: return rand.Next(1, 30); // November
                case 12: return rand.Next(1, 31); // December
                default: throw new ArgumentOutOfRangeException("Month should be a value between 1 and 12.", nameof(month));
            }
        }
    }
}
