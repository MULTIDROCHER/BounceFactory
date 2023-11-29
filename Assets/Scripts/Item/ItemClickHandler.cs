using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClickHandler : MonoBehaviour
{
    private ItemView _view;
    private PointView _pointView;

    private void Awake()
    {
        _view = FindObjectOfType<ItemView>();
        _pointView = FindObjectOfType<PointView>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            _view.ShowLevel();
            _pointView.ShowPoints();
        }
    }

    private void OnMouseUp()
    {
        _view.HideLevel();
        _pointView.HidePoints();
    }
}
