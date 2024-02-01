using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BounceFactory
{
    [RequireComponent(typeof(BonusHandler))]
    [RequireComponent(typeof(EffectApplier))]
    public class TeleportItem : Item
    {
        private readonly Color _destroyingColor = new(1, 1, 1, 0);
        private readonly float _delay = 2;

        private List<TeleportableObject> _inPortal = new();
        private Holder<Item> _holder;
        private BonusHandler _bonusHandler;
        private EffectApplier _effectApplier;
        private WaitForSeconds _wait;

        public bool CanTeleport => Movement.IsDragging == false;

        protected override void Awake()
        {
            base.Awake();
            _wait = new(_delay);
            Destroying = OnDestroying();

            _holder = ActiveComponentsProvider.ItemHolder;

            _bonusHandler = GetComponent<BonusHandler>();
            _effectApplier = GetComponent<EffectApplier>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out TeleportableObject teleportable)
            && CanTeleport && teleportable.CanBeTeleported
            && _inPortal.Contains(teleportable) == false)
                TryToTeleport(teleportable);
        }

        private IEnumerator OnDestroying()
        {
            Renderer.color = _destroyingColor;
            Destroy(LevelDisplay.gameObject);

            if (_inPortal.Count != 0)
                foreach (var ball in _inPortal)
                    Appear(ball, this);

            yield return _wait;

            Destroy(gameObject);
        }

        private void TryToTeleport(TeleportableObject teleportable)
        {
            _inPortal.Add(teleportable);

            var portal = TryFindPortal();

            if (portal != null)
                StartCoroutine(Teleportation(teleportable, portal));
            else
                StartCoroutine(Teleportation(teleportable, this));
        }

        private void Disappear(TeleportableObject teleportable)
        {
            _effectApplier.DoEffect(transform.position);
            teleportable.Disappear(transform.position);
        }

        private void Appear(TeleportableObject teleportable, TeleportItem portal)
        {
            _effectApplier.DoEffect(portal.transform.position);
            teleportable.Appear(portal.transform.position, _bonusHandler);
        }

        private IEnumerator Teleportation(TeleportableObject teleportable, TeleportItem portal)
        {
            if (teleportable != null)
                Disappear(teleportable);

            yield return _wait;

            if (teleportable != null)
                Appear(teleportable, portal);

            StartCoroutine(ReactivateTeleportable(teleportable));
            StopCoroutine(Teleportation(teleportable, portal));
        }

        private IEnumerator ReactivateTeleportable(TeleportableObject teleportable)
        {
            yield return _wait;

            _inPortal.Remove(teleportable);
            StopCoroutine(ReactivateTeleportable(teleportable));
        }

        private TeleportItem TryFindPortal() => (TeleportItem)_holder.Contents.Find(item => item != this);
    }
}