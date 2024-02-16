using System;
using System.Collections.Generic;

namespace BounceFactory.System.Game.SoundSystem
{
    public static class SoundManager
    {
        public static VolumeChanger VolumeChanger;
        public static SourcePool Pool;

        public static void SetPool(SourcePool pool) => Pool = pool;

        public static void SetVolumeChanger() => VolumeChanger = new (Pool);

        public static void PlayOneShot(SoundName sound)
        {
            if (Pool != null)
            {
                var source = Pool.SFXSources.GetValueOrDefault(sound);

                if (source != null)
                    source.PlayOneShot(source.clip);
            }
        }
    }
}