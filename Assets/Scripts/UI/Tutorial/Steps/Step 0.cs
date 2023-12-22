using System.Linq;
using UnityEngine;

public class Step0 : TutorialStep
{
    private const string MobileMessage = "нажми правую кнопку\nчтобы поднять правый флиппер";
    private const string ComputerMessage = "нажми X на клавиатуре\n чтобы поднять правый флиппер";

    private FlipperController _controller;

    public override void Enter()
    {
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x > 0).FirstOrDefault();
        _controller.Performed += OnPerformed;

        if (SystemInfo.deviceType == DeviceType.Desktop)
            OnUnneedMask(ComputerMessage);
        else
            OnNeedMask(MobileMessage, _controller.transform);
    }

    public override void Exit() => _controller.Performed -= OnPerformed;
}