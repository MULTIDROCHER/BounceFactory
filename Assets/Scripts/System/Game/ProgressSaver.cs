using BounceFactory.Score;
using BounceFactory.System.Level;
using YG;

namespace BounceFactory.System.Game
{
    public static class ProgressSaver
    {
        public static void ResetSavedProgress()
        {
            var level = YandexGame.savesData.Level > YandexGame.savesData.PreviousLevel ?
            YandexGame.savesData.Level : YandexGame.savesData.PreviousLevel;

            YandexGame.Instance._ResetSaveProgress();
            YandexGame.savesData.PreviousLevel = level;
            YandexGame.Instance._SaveProgress();
        }

        public static void SaveProgress(ProgressBar progressBar)
        {
            YandexGame.savesData.LevelScore = progressBar.CurrentScore;
            YandexGame.savesData.Balance = ScoreCounter.Instance.Balance;
            YandexGame.Instance._SaveProgress();
        }
    }
}