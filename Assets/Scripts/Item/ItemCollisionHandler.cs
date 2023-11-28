using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionHandler : MonoBehaviour
{
    public SpawnPoint PreviousPoint { get; private set; }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out SpawnPoint point) && point.IsEmpty)
            PreviousPoint = point;
    }

    public SpawnPoint GetPoint()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit.collider != null)
        {
            SpawnPoint spawnPoint = hit.collider.GetComponent<SpawnPoint>();
            if (spawnPoint != null)
            {
                Debug.Log("SpawnPoint " + spawnPoint.name + " found at Item's position!");
                return spawnPoint;
            }
            Debug.Log("No SpawnPoint." + hit.collider.name);
            return null;
        }
        else
        {
            Debug.Log("No SpawnPoint found at Item's position.");
            return null;
        }
    }
}
