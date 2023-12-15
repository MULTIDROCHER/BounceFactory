using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Step1 : TutorialStep
{
    private const string MobileMessage = "нажми в левой части экрана\nчтобы поднять левый флиппер";
    private const string ComputerMessage = "нажми Z на клавиатуре\nчтобы поднять левый флиппер";

    private GameObject _mask;
    private FlipperController _controller;

    public Step1(TMP_Text text, GameObject mask) : base(text)
    {
        _mask = mask;
    }

    public override void Enter()
    {
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x < 0).FirstOrDefault();
        _controller.Performed += OnPerformed;

        OnNeedMask();
    }

    public override void Exit()
    {
        base.Exit();
        _controller.Performed -= OnPerformed;
    }

    protected override void OnNeedMask()
    {
        base.OnNeedMask();

        ChangeText(MobileMessage);
        _mask.transform.position = GetMaskPosition(_controller.transform);
    }

    protected override void OnUnneedMask()
    {
        base.OnUnneedMask();

        ChangeText(ComputerMessage);
    }
}