using UnityEngine;

public class Step7 : TutorialStep
{
    private const string Message = "перемести один предмет на другой,\nчтобы объединить их";

    private UpgradeHandler[] _handlers;

    public override void Enter()
    {
        _handlers = Object.FindObjectsOfType<UpgradeHandler>();

        foreach (var handler in _handlers)
            handler.Performed += OnPerformed;

        OnUnneedMask(Message);
    }

    public override void Exit()
    {
        foreach (var handler in _handlers)
            handler.Performed -= OnPerformed;
    }
}