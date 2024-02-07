using System.Collections.Generic;
using YG;

namespace BounceFactory.System.DataSending
{
    public static class MetricsSender
    {
        private static readonly Dictionary<string, string> _eventParams = new ()
        {
            { "Level", YandexGame.savesData.Level.ToString() },
            { "Balance", YandexGame.savesData.Balance.ToString() },
            { "CurrentScore", YandexGame.savesData.LevelScore.ToString() },
        };

        public static void CreateMetrics(Dictionary<string, string> metrics = null)
        {
            if (metrics != null)
                SendMetrics(metrics);
            else
                SendMetrics(_eventParams);
        }

        private static void SendMetrics(Dictionary<string, string> eventParams) => YandexMetrica.Send("Выход", eventParams);
    }
}