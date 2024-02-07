using System.Linq;
using BounceFactory.Playground.FlipperSystem;
using UnityEngine;
using YG;

namespace BounceFactory.Tutorial
{
    public abstract class FlipperStep : TutorialStep
    {
        protected KeyCode ActivatorButton;
        protected FlipperActivator Activator;

        public FlipperStep(KeyCode activatorButton) => ActivatorButton = activatorButton;

        public override void Enter()
        {
            Activator = Object.FindObjectsOfType<FlipperActivator>().Where(activator => activator.KeyCode == ActivatorButton).FirstOrDefault();

            if (Activator != null)
                Activator.Performed += OnPerformed;

            if (YandexGame.EnvironmentData.isDesktop)
                OnUnneedMask(ComputerMessages()[Language]);
            else
                OnNeedMask(MobileMessages()[Language], Activator.transform);
        }

        public override void Exit()
        {
            if (Activator != null)
                Activator.Performed -= OnPerformed;
        }
    }
}