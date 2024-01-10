
using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения

        public int Level;
        public int PreviousLevel;
        public int Balance;
        public int Goal;
        public int LevelScore;

        public bool HideSaveMessage;
        public bool IsTrained;
        public bool ReviewLeft;

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны
        // Вы можете выполнить какие то действия при загрузке сохранений

        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            Level = 1;
            PreviousLevel = 0;
            Balance = 0;
            Goal = 1000;
            LevelScore = 0;
            HideSaveMessage = false;
            IsTrained = false;
        }
    }
}
