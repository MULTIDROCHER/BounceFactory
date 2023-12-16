using System.Linq;
using UnityEngine;

public class Step0 : TutorialStep
{
    private const string MobileMessage = "нажми в правой части экрана\nчтобы поднять правый флиппер";
    private const string ComputerMessage = "нажми X на клавиатуре\n чтобы поднять правый флиппер";

    private FlipperController _controller;

    public override void Enter()
    {
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x > 0).FirstOrDefault();
        _controller.Performed += OnPerformed;
        
        OnNeedMask(MobileMessage, _controller.transform);

        //or OnUnneedMask(ComputerMessage);
    }

    public override void Exit() => _controller.Performed -= OnPerformed;
}