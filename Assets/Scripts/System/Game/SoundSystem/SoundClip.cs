using System;
using UnityEngine;

namespace BounceFactory.System.Game.SoundSystem
{
    [Serializable]
    public class SoundClip
    {
        [SerializeField] private SoundName _name;
        [SerializeField] private AudioClip _clip;

        public SoundName Name => _name;
        
        public AudioClip Clip => _clip;
    }
}