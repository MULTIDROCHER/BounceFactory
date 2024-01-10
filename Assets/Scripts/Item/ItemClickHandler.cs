using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    private ItemView _view;
    private PointView _pointView;
    private BonusHandler _bonusHandler;

    private void Awake()
    {
        _view = FindObjectOfType<ItemView>();
        _pointView = FindObjectOfType<PointView>();

        TryGetComponent(out _bonusHandler);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
            OnClicked();
        else
            OnDroped();
    }

    private void OnMouseExit() => OnDroped();

    private void OnClicked()
    {
        _view.ShowLevel();
        _pointView.ShowPoints();
        SetBonusHandler(false);
    }

    private void OnDroped()
    {
        _view.HideLevel();
        _pointView.HidePoints();
        SetBonusHandler(true);
    }

    private void SetBonusHandler(bool enabled)
    {
        if (_bonusHandler != null)
            _bonusHandler.enabled = enabled;
    }
}