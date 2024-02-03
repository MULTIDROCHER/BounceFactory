using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.Tutorial.Steps
{
    public class RightFlipperStep : FlipperStep
    {
        protected override Dictionary<string, string> MobileMessages()
        {
            return new Dictionary<string, string>() {
            { "ru", "нажми правую кнопку\nчтобы поднять правый флиппер" },
            { "en", "press the right button\nto raise the right flipper" },
            { "tr", "sağ paleti kaldırmak \niçinsağ düğmeye basın" },
        };
        }

        protected override Dictionary<string, string> ComputerMessages()
        {
            return new Dictionary<string, string>() {
            { "ru", $"нажми {KeyCode} на клавиатуре\n чтобы поднять правый флиппер" },
            { "en", $"Press {KeyCode} on the keyboard\n to raise the right flipper" },
            { "tr", $"Sağ paleti kaldırmak için \nklavye üzerindeki {KeyCode} tuşuna basın" },
        };
        }

        public RightFlipperStep(KeyCode controllerKey) : base(controllerKey)
        {
        }
    }
}