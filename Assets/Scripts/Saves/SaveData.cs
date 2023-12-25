using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveData : MonoBehaviour
{
    /* [SerializeField] private BallContainer _ballContainer;
    [SerializeField] private ItemContainer _itemContainer;

    public List<GameObject> Balls { get; private set; } = new();
    public List<GameObject> Items { get; private set; } = new();
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

        //YandexGame.savesData.Balls = Balls.ToArray();
        YandexGame.savesData.Items = Items.ToArray();
        YandexGame.savesData.Balance = Balance;

        YandexGame.SaveProgress();
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        var ballSpawner = FindObjectOfType<BallSpawner>();
        var itemSpawner = FindObjectOfType<ItemSpawner>();

        if (YandexGame.savesData.Balls.Length != 0)
            for (int i = 0; i < YandexGame.savesData.Balls.Length; i++)
                ballSpawner.Spawn(YandexGame.savesData.Balls[i]);

        if (YandexGame.savesData.Items.Length != 0)
            for (int i = 0; i < YandexGame.savesData.Items.Length; i++)
                itemSpawner.Spawn(YandexGame.savesData.Items[i]);
    }

    public void SetData()
    {
        Balls.Clear();
        Balls.AddRange(_ballContainer.transform.GetComponentsInChildren<Ball>());

        Items.Clear();
        foreach(Transform item in _itemContainer.transform){
            if(item.TryGetComponent(out Item _))
            Items.Add(item.gameObject);
        }

        Balance = ScoreCounter.Instance.Balance;
    } */
}
