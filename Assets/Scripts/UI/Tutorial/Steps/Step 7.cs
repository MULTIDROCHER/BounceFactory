using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step7 : TutorialStep
{
    private const string Message = "перемести один предмет на другой,\nчтобы объединить их";

    private UpgradeHandler _handler;

    public Step7(TMP_Text text) : base(text)
    {
    }

    public override void Enter()
    {
        _handler = Object.FindObjectOfType<UpgradeHandler>();
        _handler.Performed += OnPerformed;
        OnUnneedMask();
    }

    protected override void OnUnneedMask()
    {
        base.OnUnneedMask();
        ChangeText(Message);
    }

    public override void Exit()
    {
        _handler.Performed -= OnPerformed;
        base.Exit();
    }
}