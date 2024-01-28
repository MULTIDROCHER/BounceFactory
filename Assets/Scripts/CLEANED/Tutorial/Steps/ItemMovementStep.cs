using System.Collections.Generic;
using UnityEngine;

public class ItemMovementStep : TutorialStep
{
    protected override Dictionary<string, string> CommonMessages()
    {
        return new Dictionary<string, string>() {
{ "ru", "зажми и двигай предмет,\nчтобы переместить его" },
{ "en", "pinch and move the object\nto move it" },
{ "tr", "Nesneyi hareket ettirmek için\nsıkıştırın ve hareket ettirin" },
    };}

    private ItemMovement _item;

    public override void Enter()
    {
        _item = Object.FindFirstObjectByType<ItemMovement>();
        _item.Performed += OnPerformed;

        OnUnneedMask(CommonMessages()[Language]);
    }

    public override void Exit() => _item.Performed -= OnPerformed;
}