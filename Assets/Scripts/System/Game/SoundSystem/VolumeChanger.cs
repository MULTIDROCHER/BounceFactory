using System;
using UnityEngine;

namespace BounceFactory.System.Game.SoundSystem
{
    public class VolumeChanger
    {
        private readonly SourcePool _pool;
        private readonly float _muted = 0;
        private readonly float _unmuted = 1;

        private bool _value = false;

        public event Action<bool> SFXVolumeChanged;
        public event Action<bool> MusicVolumeChanged;

        public VolumeChanger(SourcePool pool) => _pool = pool;

        public void SwitchSFXSources()
        {
            foreach (var source in _pool.SFXSources)
                SwitchSource(source.Value, out _value);

            SFXVolumeChanged?.Invoke(_value);
        }

        public void SwitchMusicSource()
        {
            SwitchSource(_pool.MusicSource, out _value);

            MusicVolumeChanged?.Invoke(_value);
        }

        private void SwitchSource(AudioSource source, out bool muted)
        {
            muted = false;

            if (source != null)
            {
                muted = Math.Abs(source.volume) < float.Epsilon;
                var value = muted ? _unmuted : _muted;

                source.volume = value;
            }
        }
    }
}