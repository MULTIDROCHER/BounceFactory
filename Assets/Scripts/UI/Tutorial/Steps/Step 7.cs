using UnityEngine;

public class Step7 : TutorialStep
{
    private const string Message = "перемести один предмет на другой,\nчтобы объединить их";

    private UpgradeHandler _handler;

    public override void Enter()
    {
        _handler = Object.FindObjectOfType<UpgradeHandler>();
        _handler.Performed += OnPerformed;
        OnUnneedMask(Message);
    }

    public override void Exit() => _handler.Performed -= OnPerformed;
}