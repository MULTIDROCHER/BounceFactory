using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.Tutorial.Steps
{
    public class LeftFlipperStep : FlipperStep
    {
        public LeftFlipperStep(KeyCode controllerKey) : base(controllerKey) { }

        protected override Dictionary<string, string> MobileMessages()
        {
            return new Dictionary<string, string>() 
        {
            { "ru", "нажми левую кнопку\nчтобы поднять левый флиппер" },
            { "en", "press the left button\nto raise the left flipper" },
            { "tr", "sol paleti kaldırmak \niçinsol düğmeye basın" },
        };
        }

        protected override Dictionary<string, string> ComputerMessages()
        {
            return new Dictionary<string, string>() 
        {
            { "ru", $"нажми {ActivatorButton} на клавиатуре\n чтобы поднять левый флиппер" },
            { "en", $"Press {ActivatorButton} on the keyboard\n to raise the left flipper" },
            { "tr", $"Sol paleti kaldırmak için \nklavyeüzerindeki {ActivatorButton} tuşuna basın" },
        };
        }
    }
}