using System;
using BounceFactory.UI.Sound;
using UnityEngine;

namespace BounceFactory.System.Game
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance;

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

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
            if (Math.Abs(source.volume) < float.Epsilon)
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