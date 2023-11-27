using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemMovement : MonoBehaviour
{
    private Camera _camera;
    private bool _isDragged = false;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = new Vector3(0, 0, 90);
    private PointView _view;
    private SpawnPoint _previousPoint;

    private void Awake()
    {
        _camera = Camera.main;
        _view = FindObjectOfType<PointView>();
        GetPoint();
    }

    private void OnMouseDown()
    {
        _isDragged = true;
        _view.ShowPoints();
        _mouseOffset = transform.position - MousePosition();
    }

    private void OnMouseDrag()
    {
        if (_isDragged)
            transform.position = MousePosition() + _mouseOffset;
    }

    private void OnMouseUp()
    {
        _isDragged = false;
        _view.HidePoints();

        transform.position = _previousPoint.transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + _rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out SpawnPoint point) && point.IsEmpty)
            _previousPoint = point;
    }

    private Vector3 MousePosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 0;
        return _camera.ScreenToWorldPoint(mouseScreenPos);
    }

    private void GetPoint()
    {
        RaycastHit2D[] hitResults = Physics2D.RaycastAll(transform.position, Vector2.zero);

        foreach (RaycastHit2D hit in hitResults)
        {
            if (hit.collider != null && hit.collider.TryGetComponent(out SpawnPoint point) && point.IsEmpty)
            {
                _previousPoint = point;
                break;
            }
        }
    }
}
