using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

public class Step1 : TutorialStep
{
    private Dictionary<string, string> _mobileMessages = new(){
{ "ru", "нажми левую кнопку\nчтобы поднять левый флиппер" },
{ "en", "press the left button\nto raise the left flipper" },
{ "tr", "sol paleti kaldırmak \niçinsol düğmeye basın" },
    };

    private Dictionary<string, string> _computerMessages = new(){
{ "ru", "нажми Z на клавиатуре\n чтобы поднять левый флиппер" },
{ "en", "Press Z on the keyboard\n to raise the left flipper" },
{ "tr", "Sol paleti kaldırmak için \nklavyeüzerindeki Z tuşuna basın" },
    };

    private FlipperController _controller;

    public override void Enter()
    {
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x < 0).FirstOrDefault();
        _controller.Performed += OnPerformed;

        if (YandexGame.EnvironmentData.isDesktop)
            OnUnneedMask(_computerMessages[Language]);
        else
            OnNeedMask(_mobileMessages[Language], _controller.transform);
    }

    public override void Exit() => _controller.Performed -= OnPerformed;
}