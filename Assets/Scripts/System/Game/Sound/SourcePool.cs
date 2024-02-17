using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.System.Game.Sound
{
    public class SourcePool
    {
        private readonly Dictionary<SoundName, AudioSource> _sfxSources = new ();
        private readonly SoundAssets _assets;
        private readonly Transform _container;

        private AudioSource _musicSource;

        public SourcePool(SoundAssets assets, Transform container)
        {
            _assets = assets;
            _container = container;

            Initiallize();
        }

        public Dictionary<SoundName, AudioSource> SFXSources => _sfxSources;

        public AudioSource MusicSource => _musicSource;

        private void Initiallize()
        {
            foreach (var sound in _assets.SoundClips)
            {
                if (sound.Name == SoundName.BackgroundMusic && _musicSource == null)
                {
                    SetMusicSource(sound);
                    continue;
                }
                else if (_sfxSources.ContainsKey(sound.Name))
                {
                    continue;
                }

                _sfxSources.Add(sound.Name, CreateSource(sound));
            }
        }

        private void SetMusicSource(SoundClip sound)
        {
            _musicSource = CreateSource(sound);
            _musicSource.loop = true;
            _musicSource.playOnAwake = true;
            _musicSource.Play();
        }

        private AudioSource CreateSource(SoundClip sound)
        {
            GameObject soundObject = new (sound.Name.ToString());
            soundObject.transform.parent = _container;

            var source = soundObject.AddComponent<AudioSource>();
            source.clip = sound.Clip;

            return source;
        }
    }
}