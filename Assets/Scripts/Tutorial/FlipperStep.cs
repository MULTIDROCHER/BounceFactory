using System.Linq;
using BounceFactory.Playground.FlipperSystem;
using UnityEngine;
using YG;

namespace BounceFactory.Tutorial
{
    public abstract class FlipperStep : TutorialStep
    {
        protected KeyCode KeyCode;
        protected FlipperActivator Controller;

        public FlipperStep(KeyCode controllerKey) => KeyCode = controllerKey;

        public override void Enter()
        {
            Controller = Object.FindObjectsOfType<FlipperActivator>().Where(controller => controller.KeyCode == KeyCode).FirstOrDefault();

            if (Controller != null)
                Controller.Performed += OnPerformed;

            if (YandexGame.EnvironmentData.isDesktop)
                OnUnneedMask(ComputerMessages()[Language]);
            else
                OnNeedMask(MobileMessages()[Language], Controller.transform);
        }

        public override void Exit()
        {
            if (Controller != null)
                Controller.Performed -= OnPerformed;
        }
    }
}