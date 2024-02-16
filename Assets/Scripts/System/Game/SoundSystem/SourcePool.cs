using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.System.Game.SoundSystem
{
    public class SourcePool
    {
        private readonly Dictionary<SoundName, AudioSource> _sfxSources = new ();
        private AudioSource _musicSource;
        private SoundAssets _assets;

        public SourcePool(SoundAssets assets) => _assets = assets;

        public Dictionary<SoundName, AudioSource> SFXSources => _sfxSources;
        public AudioSource MusicSource => _musicSource;

        public void Initiallize(Transform container)
        {
            foreach (var sound in _assets.SoundClips)
            {
                if (sound.Name == SoundName.BackgroundMusic && _musicSource == null)
                {
                    SetMusicSource(sound, container);
                    continue;
                }
                else if (_sfxSources.ContainsKey(sound.Name))
                {
                    continue;
                }

                _sfxSources.Add(sound.Name, CreateSource(sound, container));
            }
        }

        private void SetMusicSource(SoundClip sound, Transform container)
        {
            _musicSource = CreateSource(sound, container);
            _musicSource.playOnAwake = true;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        private AudioSource CreateSource(SoundClip sound, Transform container)
        {
            GameObject soundObject = new (sound.Name.ToString());
            soundObject.transform.parent = container;

            var source = soundObject.AddComponent<AudioSource>();
            source.clip = sound.Clip;

            return source;
        }
    }
}