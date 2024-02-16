using BounceFactory.System.Game.SoundSystem;

namespace BounceFactory
{
    public class SoundPlayer
    {
        private readonly SoundName _sound;

        public SoundPlayer(SoundName sound) => _sound = sound;

        public SoundName Sound => _sound;

        public void PlaySound() => SoundManager.PlayOneShot(_sound);
    }
}