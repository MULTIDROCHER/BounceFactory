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

        protected FlipperStep(TutorialGuide guide, KeyCode activatorButton) : base(guide)
        {
            ActivatorButton = activatorButton;
        }

        public override void Enter()
        {
            base.Enter();
            Activator = Guide.Activators.FirstOrDefault(activator => activator.gameObject.activeInHierarchy 
            && activator.KeyCode == ActivatorButton);

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