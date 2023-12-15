using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step5 : TutorialStep
{
    private const string Message = "зажми и двигай предмет,\nчтобы переместить его";

    private ItemMovement _item;

    public Step5(TMP_Text text) : base(text)
    {
    }

    public override void Enter()
    {
        _item = Object.FindObjectOfType<ItemMovement>();
        _item.Performed += OnPerformed;
        OnUnneedMask();
    }

    protected override void OnUnneedMask()
    {
        base.OnUnneedMask();
        ChangeText(Message);
    }

    public override void Exit()
    {
        base.Exit();
    }
}