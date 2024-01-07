using System.Collections.Generic;
using UnityEngine;

public class Step7 : TutorialStep
{
    private Dictionary<string, string> _messages = new(){
{ "ru", "перемести один предмет на другой,\nчтобы объединить их" },
{ "en", "move one item over another\nto merge them" },
{ "tr", "birleştirmek için bir öğeyi\ndiğerinin üzerine taşıyın" },
    };
    private UpgradeHandler[] _handlers;

    public override void Enter()
    {
        _handlers = Object.FindObjectsOfType<UpgradeHandler>();

        foreach (var handler in _handlers)
            handler.Performed += OnPerformed;

        OnUnneedMask(_messages[Language]);
    }

    public override void Exit()
    {
        foreach (var handler in _handlers)
            handler.Performed -= OnPerformed;
    }
}