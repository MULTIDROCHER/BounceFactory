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
            _bonusHandler.enabled = false;
        }
    }

    private void OnMouseUp()
    {
        _view.HideLevel();
        _pointView.HidePoints();
        _bonusHandler.enabled = true;
    }
}