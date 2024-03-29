using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects.BallComponents;
using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Playground.Storage.Holder;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(EffectApplier))]
    public class PortalItem : Item
    {
        private readonly List<TeleportableObject> _inPortal = new ();
        private readonly Color _destroyingColor = new (1, 1, 1, 0);
        private readonly float _delay = 2;

        private Holder<Item> _holder;
        private EffectApplier _effectApplier;
        private WaitForSeconds _wait;

        public bool CanTeleport => Movement.IsDragging == false;

        protected override void Awake()
        {
            base.Awake();
            _wait = new (_delay);
            DestroyingCoroutine = OnDestroying();

            _holder = GetComponentInParent<Holder<Item>>();
            _effectApplier = GetComponent<EffectApplier>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var teleportable = other.GetComponent<TeleportableObject>();

            if (teleportable != null && teleportable.CanBeTeleported
            && CanTeleport && _inPortal.Contains(teleportable) == false)
                Teleport(teleportable);
        }

        private IEnumerator OnDestroying()
        {
            Renderer.color = _destroyingColor;
            Destroy(LevelDisplay.gameObject);

            if (_inPortal.Count != 0)
            {
                foreach (var ball in _inPortal)
                    Appear(ball, this);
            }

            yield return _wait;

            StopAllCoroutines();
            Destroy(gameObject);
        }

        private void Teleport(TeleportableObject teleportable)
        {
            _inPortal.Add(teleportable);

            if (TryFindPortal(out PortalItem portal))
                StartCoroutine(Teleportation(teleportable, portal));
            else
                StartCoroutine(Teleportation(teleportable, this));
        }

        private void Disappear(TeleportableObject teleportable)
        {
            _effectApplier.DoEffect(transform.position);
            teleportable.Disappear(transform.position);
        }

        private void Appear(TeleportableObject teleportable, PortalItem portal)
        {
            _effectApplier.DoEffect(portal.transform.position);
            teleportable.Appear(portal.transform.position, BonusAdder);
        }

        private IEnumerator Teleportation(TeleportableObject teleportable, PortalItem portal)
        {
            if (teleportable != null)
                Disappear(teleportable);

            yield return _wait;

            if (teleportable != null)
                Appear(teleportable, portal);

            StartCoroutine(ReactivateTeleportable(teleportable));
        }

        private IEnumerator ReactivateTeleportable(TeleportableObject teleportable)
        {
            yield return _wait;

            _inPortal.Remove(teleportable);
        }

        private bool TryFindPortal(out PortalItem teleport)
        {
            teleport = _holder.Contents.FirstOrDefault(item => item != this) as PortalItem;
            return teleport != null;
        }
    }
}