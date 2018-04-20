using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Configuration;

namespace NVHarris.Helpers
{
    public static class CommonProcs
    {
        //public static string WCompanyConnStr = "Data Source=52.41.99.172;Initial Catalog=NVHarris;Persist Security Info=True;User ID=sa;Password=Sh@dow111";
        public static string WCompanyConnStr = ConfigurationManager.ConnectionStrings["NVHarrisDev"].ConnectionString;
        public static string FormatCurrency(decimal amount)
        {
            return string.Format("{0:c}", amount);

        }

        public static string FormatDecimalTwo(decimal amount)
        {
            return string.Format("{0:#.##}", amount);

        }

        internal static string StripLastComma(string s)
        {
            if (s.Length > 0)
                return s.Substring(0, s.Length - 1);
            else
                return s;
        }

        internal static DateTime GetWeekEnding(DateTime selDate)
        {
            DateTime endOfWeek;
            int thisWeekNumber = GetIso8601WeekOfYear(selDate);
            DateTime firstDayOfWeek = FirstDateOfWeek(selDate.Year, thisWeekNumber, CultureInfo.CurrentCulture);
            endOfWeek = firstDayOfWeek.AddDays(7);
            return endOfWeek;

        }

        internal static DateTime GetWeekBegin(DateTime selDate)
        {
            int thisWeekNumber = GetIso8601WeekOfYear(selDate);
            DateTime firstDayOfWeek = FirstDateOfWeek(selDate.Year, thisWeekNumber, CultureInfo.CurrentCulture);
            return firstDayOfWeek.AddDays(1);
        }


        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }


    }
}
