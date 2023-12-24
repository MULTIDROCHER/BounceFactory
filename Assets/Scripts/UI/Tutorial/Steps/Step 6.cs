using System.Collections.Generic;
using UnityEngine;

public class Step6 : TutorialStep
{
    private Dictionary<string, string> _messages = new(){
{ "ru", "теперь добавь еще один предмет" },
{ "en", "now add one more item" },
{ "tr", "şimdi bir öğe daha ekleyin" },
    };

    private ItemSpawner _spawner;

    public override void Enter()
    {
        _spawner = Object.FindObjectOfType<ItemSpawner>();
        _spawner.ItemBought += OnPerformed;
        OnUnneedMask(_messages[Language]);
    }

    public override void Exit() => _spawner.ItemBought -= OnPerformed;
}