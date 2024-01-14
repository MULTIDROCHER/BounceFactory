using UnityEngine;

[RequireComponent(typeof(ItemMovement))]
public class ItemClickHandler : MonoBehaviour
{
    private ItemView _view;
    private PointView _pointView;
    private BonusHandler _bonusHandler;
    private ItemMovement _itemMovement;

    private void Awake()
    {
        _view = FindObjectOfType<ItemView>();
        _pointView = FindObjectOfType<PointView>();

        TryGetComponent(out _bonusHandler);
        TryGetComponent(out _itemMovement);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            OnClick();
        else if(Input.GetMouseButtonUp(0))
            OnDrop();
    }

    public void OnClick()
    {
        _view.ShowLevel();
        _pointView.ShowPoints();
        _itemMovement.OnStartMovement();
        SetBonusHandler(false);
    }

    public void OnDrop()
    {
        _view.HideLevel();
        _pointView.HidePoints();
        _itemMovement.OnEndMovement();
        SetBonusHandler(true);
    }

    private void SetBonusHandler(bool enabled)
    {
        if (_bonusHandler != null)
            _bonusHandler.enabled = enabled;
    }
}