using UnityEngine;

namespace BounceFactory.System.Game.Sound
{
    public static class SourceProvider
    {
        public static SoundSystem SoundSystem { get; private set; }

        public static AudioSource GetSFXSource(SoundName sound)
        {
            if (SoundSystem != null && SoundSystem.Pool.SFXSources.TryGetValue(sound, out AudioSource source))
                return source;
            else
                return null;
        }

        public static void Prepare(SoundSystem system) => SoundSystem = system;
    }
}