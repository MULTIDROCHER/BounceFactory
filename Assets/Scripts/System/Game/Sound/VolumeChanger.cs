using UnityEngine;

namespace BounceFactory.System.Game.Sound
{
    public class VolumeChanger
    {
        public void Mute() => AudioListener.volume = 0;

        public void Unmute() => AudioListener.volume = 1;
    }
}