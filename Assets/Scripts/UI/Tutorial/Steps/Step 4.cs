using System.Linq;
using UnityEngine;

public class Step4 : TutorialStep
{
    private const string Message = "теперь создай предмет,\nчтобы шарам было с чем сталкиваться";

    private ItemSpawner _spawner;
    private PriceDisplay _target;

    public override void Enter()
    {
        _spawner = Object.FindObjectOfType<ItemSpawner>();
        _target = Object.FindObjectsOfType<PriceDisplay>().FirstOrDefault(display => display.Seller.GetComponent<ItemSeller>());
        _spawner.ItemBought += OnPerformed;
        OnNeedMask(Message, _target.transform);
    }

    public override void Exit() => _spawner.ItemBought -= OnPerformed;
}