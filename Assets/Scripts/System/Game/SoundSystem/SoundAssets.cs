using UnityEngine;

namespace BounceFactory.System.Game.SoundSystem
{
    public class SoundAssets : MonoBehaviour
    {
        private static SoundAssets _instance;

        private readonly string _containerName = "container";

        [SerializeField] private SoundClip[] _clips;
        [SerializeField] private Transform _container;

        private SourcePool _pool;

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

            SetContainer();
            _pool = new (this);
            _pool.Initiallize(_container);

            SoundManager.SetPool(_pool);
            SoundManager.SetVolumeChanger();
        }

        private void SetContainer()
        {
            if (_container == null)
            {
                _container = new GameObject(_containerName).transform;
                _container.parent = transform;
            }
        }
    }
}