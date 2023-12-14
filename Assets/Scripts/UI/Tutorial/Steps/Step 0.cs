using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Step0 : TutorialStep
{
    private const string MobileMessage = "нажми в правой части экрана чтобы поднять правый флиппер";
    private const string ComputerMessage = "нажми X на клавиатуре чтобы поднять правый флиппер";

    private GameObject _mask;
    private FlipperController _controller;

    public Step0(TMP_Text text, GameObject mask) : base(text)
    {
        _mask = mask;
    }

    public override void Enter()
    {
        OnComputer();
        
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x > 0).FirstOrDefault();
        _controller.Performed += OnCompleted;
    }

    public override void Exit()
    {
        _controller.Performed -= OnCompleted;
    }

    protected override void OnMobile()
    {
        base.OnMobile();

        ChangeText(MobileMessage);
        _mask.transform.position = GetMaskPosition(_controller.transform);
    }

    protected override void OnComputer()
    {
        base.OnComputer();

        ChangeText(ComputerMessage);
    }
}