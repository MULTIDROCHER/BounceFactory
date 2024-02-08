using BounceFactory.System.Level;
using YG;

namespace BounceFactory.System.Game
{
    public class ProgressSaver
    {
        private readonly ProgressBar _progressBar;

        public ProgressSaver(ProgressBar progressBar = null)
        {
            _progressBar = progressBar;
        }

        public void ResetSavedProgress()
        {
            var level = YandexGame.savesData.Level > YandexGame.savesData.PreviousLevel ?
            YandexGame.savesData.Level : YandexGame.savesData.PreviousLevel;

            YandexGame.Instance._ResetSaveProgress();
            YandexGame.savesData.PreviousLevel = level;
            YandexGame.Instance._SaveProgress();
        }

        public void SaveProgress()
        {
            if (_progressBar != null)
                YandexGame.savesData.LevelScore = _progressBar.CurrentScore;

            YandexGame.savesData.Balance = _progressBar.Counter.Balance;
            YandexGame.Instance._SaveProgress();
        }
    }
}