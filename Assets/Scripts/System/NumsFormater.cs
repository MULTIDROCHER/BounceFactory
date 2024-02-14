using YG;

namespace BounceFactory.System
{
    public static class NumsFormater
    {
        private static readonly string[] _enNames = new []
        {
            string.Empty,
            "K",
            "M",
            "B",
            "T",
            "QD",
            "QN",
        };

        private static readonly string[] _ruNames = new []
        {
            string.Empty,
            "Т",
            "МЛ",
            "МД",
            "ТР",
            "КВ",
            "КТ",
        };

        private static readonly string[] _trNames = new []
        {
            string.Empty,
            "B",
            "ML",
            "BL",
            "TR",
            "KR",
            "KT",
        };

        public static string FormatedNumber(decimal number)
        {
            var names = GetNames();

            if (number == 0)
                return "0";

            int i = 0;

            while (i + 1 < names.Length && number >= 1000)
            {
                number /= 1000;
                i++;
            }

            return number.ToString(format: "#.##") + names[i];
        }

        private static string[] GetNames() => YandexGame.lang switch
        {
            "ru" => _ruNames,
            "tr" => _trNames,
            _ => _enNames,
        };
    }
}