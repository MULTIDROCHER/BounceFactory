using System;
using UnityEngine;


public class BallSpawner : Spawner<Ball>
{
    public override event Action Bought;

    public override void Spawn()
    {
        if (Holder == null)
            SetHolder();

        Instantiate(GetTemplateToSpawn(), Holder.transform.position, Quaternion.identity, Holder.transform);
        ScoreCounter.Instance.Buy(PriceChanger.Price);
        Bought?.Invoke();
    }

    public void SetHolder(BallHolder holder = null)
    {
        if (holder == null)
            Holder = FindFirstObjectByType<BallHolder>();
        else
            Holder = holder;

        if (Holder.transform.childCount == 0)
            Instantiate(GetTemplateToSpawn(), Holder.transform.position, Quaternion.identity, Holder.transform);
    }
}