using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int CalcDifference(string date1, string date2)
        {
            DateTime first = DateTime.Parse(date1);
            DateTime second = DateTime.Parse(date2);
            var diff = first - second;

            return Math.Abs(diff.Days);
        }
    }
}
