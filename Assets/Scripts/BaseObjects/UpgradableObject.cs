using BounceFactory.ScoreSystem;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class UpgradableObject : MonoBehaviour
    {
        protected int BonusIncrease;
        protected int ObjectsAmount;

        private SpriteRenderer _renderer;
        private ScoreOperations _scoreOperations;

        public SpriteRenderer Renderer => _renderer;

        public ScoreOperations ScoreOperations => _scoreOperations;

        public int Level { get; protected set; } = 1;

        public int Bonus { get; protected set; } = 1;

        protected virtual void Awake() => _renderer = GetComponent<SpriteRenderer>();

        public virtual void LevelUp()
        {
            Level++;
            Bonus = IncreaseBonus();
            gameObject.name = Level.ToString();
        }

        public void SetScoreOperator(ScoreOperations operations) => _scoreOperations = operations;

        protected virtual int IncreaseBonus() => (Bonus * ObjectsAmount) + BonusIncrease;
    }
}