using UnityEngine;

[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(BonusHandler))]
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

        _bonusHandler = GetComponent<BonusHandler>();
        _itemMovement = GetComponent<ItemMovement>();
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