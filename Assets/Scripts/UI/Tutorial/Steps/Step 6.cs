using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step6 : TutorialStep
{
    private const string Message = "теперь добавь еще один предмет";

    private ItemSpawner _spawner;

    public Step6(TMP_Text text) : base(text)
    {
    }

    public override void Enter()
    {
        _spawner = Object.FindObjectOfType<ItemSpawner>();
        OnUnneedMask();
    }

    protected override void OnUnneedMask()
    {
        base.OnUnneedMask();
        ChangeText(Message);
        _spawner.ItemBought += OnPerformed;
    }

    public override void Exit()
    {
        _spawner.ItemBought -= OnPerformed;
        base.Exit();
    }
}