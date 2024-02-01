using System;
using UnityEngine;

namespace BounceFactory
{
    public class BallSpawner : Spawner<Ball>
    {
        public override event Action Bought;

        public override void Spawn()
        {
            if (Holder == null)
                OnLevelChanged();

            Instantiate(GetTemplateToSpawn(), Holder.transform.position, Quaternion.identity, Holder.transform);
            ScoreCounter.Instance.Buy(PriceChanger.Price);
            Bought?.Invoke();
        }

        protected override void OnLevelChanged()
        {
            Holder = ActiveComponentsProvider.BallHolder;

            if (Holder.transform.childCount == 0)
                Instantiate(GetTemplateToSpawn(), Holder.transform.position, Quaternion.identity, Holder.transform);
        }
    }
}