using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    public class EffectApplier : MonoBehaviour
    {
        private readonly float _delay = 2;

        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private ParticleSystem _upgradeEffect;

        public void DoEffect(Ball ball)
        {
            var effect = Instantiate(_effect, ball.transform.position, Quaternion.identity, ball.transform);
            Destroy(effect.gameObject, _delay);
        }

        public void DoEffect(Vector3 position, Transform parent) => Instantiate(_effect, position, Quaternion.identity, parent);

        public void DoEffect(Vector3 position) => Instantiate(_effect, position, Quaternion.identity, transform);

        public void DoEffect(ParticleSystem effect, Vector3 position) => Instantiate(effect, position, Quaternion.identity, transform);

        public void DoUpgradeEffect(Transform item) => Instantiate(_upgradeEffect, item);
    }
}