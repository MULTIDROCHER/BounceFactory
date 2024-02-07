using System;

namespace BounceFactory.System
{
    public static class ToStringConverter
    {
        public static string GetTextWithNumber(string text, int number)
        {
            return text + number.ToString();
        }

        public static string ConvertProgress(int current, string splitter, int goal)
        {
            return NumsFormater.FormatedNumber(current) + splitter + NumsFormater.FormatedNumber(goal);
        }
    }
}