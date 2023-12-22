using System.Linq;
using UnityEngine;

public class Step1 : TutorialStep
{
    private const string MobileMessage = "нажми лдевую кнопку\nчтобы поднять левый флиппер";
    private const string ComputerMessage = "нажми Z на клавиатуре\nчтобы поднять левый флиппер";

    private FlipperController _controller;

    public override void Enter()
    {
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x < 0).FirstOrDefault();
        _controller.Performed += OnPerformed;

        if (SystemInfo.deviceType == DeviceType.Desktop)
            OnUnneedMask(ComputerMessage);
        else
            OnNeedMask(MobileMessage, _controller.transform);
    }

    public override void Exit() => _controller.Performed -= OnPerformed;
}