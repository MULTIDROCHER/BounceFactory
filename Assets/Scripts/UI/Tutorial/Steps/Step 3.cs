using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step3 : TutorialStep
{
    private const string Message = "когда у тебя достаточно шаров одного\nуровня, ты можешь их объединять";

    private GameObject _mask;
    private BallMerger _merger;

    public Step3(TMP_Text text, GameObject mask) : base(text)
    {
        _mask = mask;
    }

    public override void Enter()
    {
        _merger = Object.FindObjectOfType<BallMerger>();
        OnNeedMask();
    }

    protected override void OnNeedMask()
    {
        base.OnNeedMask();
        ChangeText(Message);
        _merger.Performed += OnPerformed;
        _mask.transform.position = GetMaskPosition(_merger.Button.transform);
    }

    public override void Exit()
    {
        base.Exit();
        _merger.Performed -= OnPerformed;
    }
}