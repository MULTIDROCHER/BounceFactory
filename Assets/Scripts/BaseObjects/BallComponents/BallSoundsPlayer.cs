using BounceFactory.Playground.DeadZones;
using BounceFactory.System.Game.Sound;
using UnityEngine;

namespace BounceFactory.BaseObjects.BallComponents
{
    [RequireComponent(typeof(SoundPlayer))]
    [RequireComponent(typeof(TeleportableObject))]
    public class BallSoundsPlayer : MonoBehaviour
    {
        private TeleportableObject _teleportable;
        private SoundPlayer _player;

        private void Awake()
        {
            _teleportable = GetComponent<TeleportableObject>();
            _player = GetComponent<SoundPlayer>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out DeadZone _) == false)
                _player.Play(default);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.TryGetComponent(out Item item);

            switch (item)
            {
                case PortalItem teleport when teleport.CanTeleport
                && _teleportable.CanBeTeleported:
                    _player.Play(SoundName.Teleportation);
                    break;
                case BallGeneratorItem generator when generator.IsActive:
                    _player.Play(SoundName.BallGeneration);
                    break;
                case AccelerationItem:
                    _player.Play(SoundName.Acceleration);
                    break;
            }
        }
    }
}