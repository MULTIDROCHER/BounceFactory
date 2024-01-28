using System.Collections.Generic;
using UnityEngine;

public class BallsMergeStep : TutorialStep
{
    protected override Dictionary<string, string> CommonMessages()
    {
        return new Dictionary<string, string>() {
{ "ru", "когда у тебя достаточно шаров одного\nуровня, ты можешь их объединять" },
{ "en", "when you have enough balls of the\nsame level, you can merge them" },
{ "tr", "Aynı seviyede yeterince topunuz \nolduğunda,onları birleştirebilirsiniz" },
    };
    }

    private BallMerger _merger;

    public override void Enter()
    {
        _merger = Object.FindFirstObjectByType<BallMerger>();
        _merger.Performed += OnPerformed;
        OnNeedMask(CommonMessages()[Language], _merger.Button.transform);
    }

    public override void Exit() => _merger.Performed -= OnPerformed;
}