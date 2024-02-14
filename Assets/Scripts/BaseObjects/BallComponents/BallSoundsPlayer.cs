using BounceFactory.Playground.DeadZones;
using BounceFactory.System.Game.SoundSystem;
using UnityEngine;

namespace BounceFactory.BaseObjects.BallComponents
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(TeleportableObject))]
    public class BallSoundsPlayer : MonoBehaviour
    {
        private TeleportableObject _teleportable;

        private void Awake() => _teleportable = GetComponent<TeleportableObject>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out DeadZone _) == false)
                PlaySound(Sound.BallBounce);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.TryGetComponent(out Item item);

            switch (item)
            {
                case PortalItem teleport when teleport.CanTeleport
                && _teleportable.CanBeTeleported:
                    PlaySound(Sound.Teleportation);
                    break;
                case BallGeneratorItem generator when generator.IsActive:
                    PlaySound(Sound.BallGeneration);
                    break;
                case AccelerationItem:
                    PlaySound(Sound.Acceleration);
                    break;
            }
        }

        private void PlaySound(Sound sound) => SoundManager.PlayOneShot(sound);
    }
}