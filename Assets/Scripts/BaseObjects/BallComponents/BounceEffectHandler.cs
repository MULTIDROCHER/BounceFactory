using BounceFactory.Playground.Storage;
using UnityEngine;

namespace BounceFactory.BaseObjects.BallComponents
{
    [RequireComponent(typeof(Ball))]
    public class BounceEffectHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;

        private EffectContainer _container;
        private Ball _ball;

        private void Start()
        {
            _ball = GetComponent<Ball>();
            _container = _ball.EffectContainer;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_container!= null)
                Instantiate(_effect, other.GetContact(0).point, Quaternion.identity, _container.transform);
        }
    }
}