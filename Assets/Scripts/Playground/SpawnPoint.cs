using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set; } = true;
    public Item Item { get; private set; }

    private SpriteRenderer _renderer;

    private void Awake()
    {
        TryGetComponent(out _renderer);
        HidePoint();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Item = item;
            IsEmpty = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item) && item == Item)
        {
            Item = null;
            IsEmpty = true;
        }
    }

    public void ShowPoint() => _renderer.enabled = true;

    public void HidePoint() => _renderer.enabled = false;
}