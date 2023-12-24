using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Step4 : TutorialStep
{
    private Dictionary<string, string> _messages = new(){
{ "ru", "теперь создай предмет,\nчтобы шарам было с чем сталкиваться" },
{ "en", "Now create an object so the balls\nhave something to collide with" },
{ "tr", "Şimdi bir nesne oluşturun, böylece\ntopların uğraşacağı bir şey olsun" },
    };

    private ItemSpawner _spawner;
    private PriceDisplay _target;

    public override void Enter()
    {
        _spawner = Object.FindObjectOfType<ItemSpawner>();
        _target = Object.FindObjectsOfType<PriceDisplay>().FirstOrDefault(display => display.Seller.GetComponent<ItemSeller>());
        _spawner.ItemBought += OnPerformed;
        OnNeedMask(_messages[Language], _target.transform.parent.parent);
    }

    public override void Exit() => _spawner.ItemBought -= OnPerformed;
}