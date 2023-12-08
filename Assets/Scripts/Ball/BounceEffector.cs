using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bounceEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(_bounceEffect, other.GetContact(0).point, Quaternion.identity);
    }
}
