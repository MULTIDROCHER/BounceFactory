using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.System.Game.SoundSystem
{
    public static class SoundManager
    {
        public static VolumeChanger VolumeChanger = new ();

        public static void PlayOneShot(Sound sound)
        {
            var source = SourcePool.SFXSources.GetValueOrDefault(sound);

            if (source != null)
                source.PlayOneShot(source.clip);
        }

        public static void PlayOneShot(AudioSource source)
        {
            if(source != null)
                source.PlayOneShot(source.clip);
        }
    }
}