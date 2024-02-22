using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.System.Game.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private List<SoundClip> _clips = new ();

        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _source.playOnAwake = false;
            _source.loop = false;
        }

        public void Play(SoundName sound) => _source.PlayOneShot(GetClip(sound));

        private AudioClip GetClip(SoundName name)
        {
            if (name == default)
                return _source.clip;

            foreach (var clip in _clips)
            {
                if (clip.Name == name)
                    return clip.Clip;
            }

            return _source.clip;
        }
    }
}