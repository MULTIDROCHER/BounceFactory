using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isEmpty = true;

    public bool IsEmpty => _isEmpty;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
            _isEmpty = false;
    }
}
