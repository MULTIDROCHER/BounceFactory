using System.Collections.Generic;
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
        private SoundPlayer[] _players;

        private void Awake()
        {
            _teleportable = GetComponent<TeleportableObject>();
            _players = new []
            {
                new SoundPlayer(SoundName.BallBounce),
                new SoundPlayer(SoundName.Teleportation),
                new SoundPlayer(SoundName.BallGeneration),
                new SoundPlayer(SoundName.Acceleration),
            };
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out DeadZone _) == false)
                PlaySound(SoundName.BallBounce);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.TryGetComponent(out Item item);

            switch (item)
            {
                case PortalItem teleport when teleport.CanTeleport
                && _teleportable.CanBeTeleported:
                    PlaySound(SoundName.Teleportation);
                    break;
                case BallGeneratorItem generator when generator.IsActive:
                    PlaySound(SoundName.BallGeneration);
                    break;
                case AccelerationItem:
                    PlaySound(SoundName.Acceleration);
                    break;
            }
        }

        private void PlaySound(SoundName sound)
        {
            foreach (var player in _players)
            {
                if (player.Sound == sound)
                {
                    player.PlaySound();
                    return;
                }
            }
        }
    }
}