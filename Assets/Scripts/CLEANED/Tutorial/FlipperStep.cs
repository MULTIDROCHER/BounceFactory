using System.Linq;
using UnityEngine;
using YG;

public abstract class FlipperStep : TutorialStep
{
    protected KeyCode KeyCode;
    protected FlipperController Controller;

    public FlipperStep(KeyCode controllerKey) => KeyCode = controllerKey;

    public override void Enter()
    {
        Controller = Object.FindObjectsOfType<FlipperController>().Where(controller => controller.KeyCode == KeyCode).FirstOrDefault();

        Controller.Performed += OnPerformed;

        if (YandexGame.EnvironmentData.isDesktop)
            OnUnneedMask(ComputerMessages()[Language]);
        else
            OnNeedMask(MobileMessages()[Language], Controller.transform);
    }

    public override void Exit() => Controller.Performed -= OnPerformed;
}