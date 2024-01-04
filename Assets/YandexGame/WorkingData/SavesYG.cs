
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

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public int Level;
        public int PreviousLevel;
        public int Balance;
        public int Goal;
        public int LevelScore;

        public bool HideSaveMessage;
        public bool IsTrained;

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            openLevels[1] = true;
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            Balance = 0;
            Level = 1;
            Goal = 1000;
            LevelScore = 0;
            IsTrained = false;
            HideSaveMessage = false;
        }
    }
}
