using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpawnPoint : MonoBehaviour
{
    private SpriteRenderer _renderer;

    public Item Item { get; private set; }
    public bool IsEmpty { get; private set; } = true;

    private void Awake()
    {
        TryGetComponent(out _renderer);
        HidePoint();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item) && IsEmpty)
        {
            Item = item;
            IsEmpty = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Item != null && other.gameObject == Item.gameObject)
        {
            Item = null;
            IsEmpty = true;
        }
    }

    public void ShowPoint() => _renderer.enabled = true;

    public void HidePoint() => _renderer.enabled = false;
}