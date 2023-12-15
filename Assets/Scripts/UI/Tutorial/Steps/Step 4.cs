using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step4 : TutorialStep
{
    private const string Message = "теперь создай предмет,\nчтобы шарам было с чем сталкиваться";

    private GameObject _mask;
    private ItemSpawner _spawner;
    private PriceDisplay _target;

    public Step4(TMP_Text text, GameObject mask) : base(text)
    {
        _mask = mask;
    }

    public override void Enter()
    {
        _spawner = Object.FindObjectOfType<ItemSpawner>();
        _target = Object.FindObjectsOfType<PriceDisplay>().FirstOrDefault(display => display.Seller.GetComponent<ItemSeller>());
        OnNeedMask();
    }

    protected override void OnNeedMask()
    {
        base.OnNeedMask();
        ChangeText(Message);
        _spawner.ItemBought += OnPerformed;
        _mask.transform.position = GetMaskPosition(_target.transform);
    }

    public override void Exit()
    {
        _spawner.ItemBought -= OnPerformed;
        base.Exit();
    }
}