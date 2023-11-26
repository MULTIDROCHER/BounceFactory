using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Camera _camera;
    private bool _isDragged = false;
    private Vector3 _mouseStartPos;
    private Vector3 _itemStartPos;
    private SpawnPoint _previousPoint;

    private void Awake()
    {
        _camera = Camera.main;
        GetPoint();
    }

    private void OnMouseDown()
    {
        _isDragged = true;
        _mouseStartPos = MousePosition();
        _itemStartPos = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (_isDragged)
            transform.localPosition = _itemStartPos + MousePosition() - _mouseStartPos;
    }

    private void OnMouseUp()
    {
        _isDragged = false;

        transform.position = _previousPoint.transform.position;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f); // Adjust the radius value as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out SpawnPoint point) && point.IsEmpty)
            {
                _previousPoint = point;
                break;
            }
        }
    }

    private bool GetHit(out RaycastHit2D hit)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        hit = Physics2D.Raycast(ray.origin, ray.direction);

        return hit.collider != null;
    }
}
