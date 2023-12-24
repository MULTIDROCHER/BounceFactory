using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveData : MonoBehaviour
{
    [SerializeField] private BallContainer _ballContainer;
    [SerializeField] private ItemContainer _itemContainer;

    public List<Ball> Balls { get; private set; }
    public List<Item> Items { get; private set; }
    public int Balance { get; private set; }

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        SetData();

        YandexGame.savesData.Balls = Balls;
        YandexGame.savesData.Items = Items;
        YandexGame.savesData.Balance = Balance;

        YandexGame.SaveProgress();
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        var ballSpawner = FindObjectOfType<BallSpawner>();
        var itemSpawner = FindObjectOfType<ItemSpawner>();

        if (YandexGame.savesData.Balls.Count != 0)
            foreach (var ball in YandexGame.savesData.Balls)
                ballSpawner.Spawn(ball);

        if (YandexGame.savesData.Items.Count != 0)
        foreach (var item in YandexGame.savesData.Items)
            itemSpawner.Spawn(item);
    }

    public void SetData()
    {
        SetChilds(Balls, _ballContainer.transform);
        SetChilds(Items, _itemContainer.transform);
        Balance = ScoreCounter.Instance.Balance;
    }

    private void SetChilds<T>(List<T> list, Transform container)
    {
        if (list.Count != 0)
            list.Clear();

        list.AddRange(container.GetComponentsInChildren<T>());
    }
}
