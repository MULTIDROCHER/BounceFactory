using UnityEngine;

namespace BounceFactory.System.Game.Sound
{
    public class SoundAssets : MonoBehaviour
    {
        private static SoundAssets _instance;

        [SerializeField] private SoundClip[] _clips;
        [SerializeField] private Transform _container;

        private SourcePool _pool;
        private SoundSystem _soundSystem;

        public SoundClip[] SoundClips => _clips;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _pool = new (this, _container);
            _soundSystem = new (_pool);
            SourceProvider.Prepare(_soundSystem);
        }
    }
}