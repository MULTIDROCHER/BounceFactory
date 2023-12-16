using UnityEngine;

public class Step6 : TutorialStep
{
    private const string Message = "теперь добавь еще один предмет";

    private ItemSpawner _spawner;

    public override void Enter()
    {
        _spawner = Object.FindObjectOfType<ItemSpawner>();
        _spawner.ItemBought += OnPerformed;
        OnUnneedMask(Message);
    }

    public override void Exit() => _spawner.ItemBought -= OnPerformed;
}