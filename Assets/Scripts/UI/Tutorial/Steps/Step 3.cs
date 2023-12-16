using UnityEngine;

public class Step3 : TutorialStep
{
    private const string Message = "когда у тебя достаточно шаров одного\nуровня, ты можешь их объединять";

    private BallMerger _merger;

    public override void Enter()
    {
        _merger = Object.FindObjectOfType<BallMerger>();
        _merger.Performed += OnPerformed;
        OnNeedMask(Message, _merger.Button.transform);
    }

    public override void Exit() => _merger.Performed -= OnPerformed;
}