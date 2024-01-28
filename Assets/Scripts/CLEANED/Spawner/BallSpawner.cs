using System;
using UnityEngine;


public class BallSpawner : Spawner<Ball>
{
    public override event Action Bought;

    public override void Spawn()
    {
        if (Container == null)
            GetContainer();

        Instantiate(GetTemplateToSpawn(), Container.transform.position, Quaternion.identity, Container.transform);
        ScoreCounter.Instance.Buy(_seller.Price);
        Bought?.Invoke();
    }

    public void GetContainer(BallContainer container = null)
    {
        if (container == null)
            Container = FindObjectOfType<BallContainer>();
        else
            Container = container;

        if (Container.transform.childCount == 0)
            Instantiate(GetTemplateToSpawn(), Container.transform.position, Quaternion.identity, Container.transform);
    }
}