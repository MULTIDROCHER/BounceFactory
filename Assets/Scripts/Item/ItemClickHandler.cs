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
        _bonusHandler = GetComponent<BonusHandler>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            _view.ShowLevel();
            _pointView.ShowPoints();
            SetBonus(false);
        }
    }

    private void OnMouseExit()
    {
        if (Input.GetMouseButton(0) == false)
        {
            _view.HideLevel();
            _pointView.HidePoints();
            SetBonus(true);
        }
    }

    private void SetBonus(bool enabled)
    {
        if (_bonusHandler != null)
            _bonusHandler.enabled = enabled;
    }
}