using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpawnPoint : MonoBehaviour
{
    private bool _isEmpty = true;
    private SpriteRenderer _renderer;

    public bool IsEmpty => _isEmpty;

    private void Awake()
    {
        TryGetComponent(out _renderer);
        HidePoint();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
            _isEmpty = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
            _isEmpty = true;
    }

    public void ShowPoint() => _renderer.enabled = true;

    public void HidePoint() => _renderer.enabled = false;
}