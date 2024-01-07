using System.Collections.Generic;
using UnityEngine;

public class Step5 : TutorialStep
{
    private Dictionary<string, string> _messages = new(){
{ "ru", "зажми и двигай предмет,\nчтобы переместить его" },
{ "en", "pinch and move the object\nto move it" },
{ "tr", "Nesneyi hareket ettirmek için\nsıkıştırın ve hareket ettirin" },
    };
    private ItemMovement _item;

    public override void Enter()
    {
        _item = Object.FindObjectOfType<ItemMovement>();
        _item.Performed += OnPerformed;

        OnUnneedMask(_messages[Language]);
    }

    public override void Exit() => _item.Performed -= OnPerformed;
}