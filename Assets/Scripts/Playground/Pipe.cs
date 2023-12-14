using UnityEngine;

public class Pipe : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out BounceHandler bounce))
            bounce.DisableMaterial();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out BounceHandler bounce))
            bounce.EnableMaterial();
    }
}