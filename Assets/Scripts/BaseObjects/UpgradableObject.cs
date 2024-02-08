using BounceFactory.Score;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class UpgradableObject : MonoBehaviour
    {
        protected int BonusIncrease;
        protected int ObjectsAmount;

        private SpriteRenderer _renderer;
        private ScoreCounter _scoreCounter;

        public SpriteRenderer Renderer => _renderer;

        public ScoreCounter ScoreCounter => _scoreCounter;

        public int Level { get; protected set; } = 1;
        
        public int Bonus { get; protected set; } = 1;

        protected virtual void Awake() => _renderer = GetComponent<SpriteRenderer>();

        public virtual void LevelUp()
        {
            Level++;
            Bonus = IncreaseBonus();
            gameObject.name = Level.ToString();
        }

        protected virtual int IncreaseBonus() => (Bonus * ObjectsAmount) + BonusIncrease;

        public void GetCounter(ScoreCounter counter) => _scoreCounter = counter; 
    }
}