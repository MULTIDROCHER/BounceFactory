using System;
using UnityEngine;

namespace BounceFactory
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        public static AudioManager Instance;

        public event Action<float> VolumeChanged;

        public AudioSource MusicSource => _musicSource;
        public AudioSource SFXSource => _sfxSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SwitchSource(AudioSource source, SoundButton button)
        {
            if (source.volume == 0)
                Unmute(source, button);
            else
                Mute(source, button);

            if (source == _sfxSource)
                VolumeChanged?.Invoke(source.volume);
        }

        private void Mute(AudioSource source, SoundButton button)
        {
            source.volume = 0;
            button.Mute();
        }

        private void Unmute(AudioSource source, SoundButton button)
        {
            source.volume = 1;
            button.Unmute();
        }
    }
}