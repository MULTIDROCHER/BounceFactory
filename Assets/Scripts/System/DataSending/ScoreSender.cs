using UnityEngine;
using YG;

namespace BounceFactory.System.DataSending
{
    public class ScoreSender : MonoBehaviour
    {
        public void RewriteLeaderboardScore()
        {
            if (YandexGame.savesData.PreviousLevel < YandexGame.savesData.Level)
            {
                YandexGame.savesData.PreviousLevel = YandexGame.savesData.Level;
                YandexGame.NewLeaderboardScores("LBLevel", YandexGame.savesData.PreviousLevel);
            }
        }
    }
}