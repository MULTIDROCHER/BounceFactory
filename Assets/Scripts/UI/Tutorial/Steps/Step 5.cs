using UnityEngine;

public class Step5 : TutorialStep
{
    private const string Message = "зажми и двигай предмет,\nчтобы переместить его";

    private ItemMovement _item;

    public override void Enter()
    {
        _item = Object.FindObjectOfType<ItemMovement>();
        _item.Performed += OnPerformed;
        OnUnneedMask(Message);
    }

    public override void Exit() => _item.Performed -= OnPerformed;
}