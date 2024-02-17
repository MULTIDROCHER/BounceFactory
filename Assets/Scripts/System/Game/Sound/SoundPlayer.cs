using UnityEngine;

namespace BounceFactory.System.Game.Sound
{
    public class SoundPlayer
    {
        private readonly SoundName _sound;
        private readonly AudioSource _source;

        public SoundPlayer(SoundName sound)
        {
            _sound = sound;
            _source = SourceProvider.GetSFXSource(_sound);
        }

        public SoundName Sound => _sound;

        public void PlaySound()
        {
            if (_source != null)
                _source.PlayOneShot(_source.clip);
        }
    }
}