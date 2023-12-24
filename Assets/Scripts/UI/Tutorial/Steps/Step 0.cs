using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

public class Step0 : TutorialStep
{
    private Dictionary<string, string> _mobileMessages = new(){
{ "ru", "нажми правую кнопку\nчтобы поднять правый флиппер" },
{ "en", "press the right button\nto raise the right flipper" },
{ "tr", "sağ paleti kaldırmak \niçinsağ düğmeye basın" },
    };

    private Dictionary<string, string> _computerMessages = new(){
{ "ru", "нажми X на клавиатуре\n чтобы поднять правый флиппер" },
{ "en", "Press X on the keyboard\n to raise the right flipper" },
{ "tr", "Sağ paleti kaldırmak için \nklavye üzerindeki X tuşuna basın" },
    };

    private FlipperController _controller;

    public override void Enter()
    {
        _controller = Object.FindObjectsOfType<FlipperController>()
            .Where(controller => controller.transform.position.x > 0).FirstOrDefault();
        _controller.Performed += OnPerformed;

        if (YandexGame.EnvironmentData.isDesktop)
            OnUnneedMask(_computerMessages[Language]);
        else
            OnNeedMask(_mobileMessages[Language], _controller.transform);
    }

    public override void Exit() => _controller.Performed -= OnPerformed;
}