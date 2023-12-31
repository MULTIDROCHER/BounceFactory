using System;
using UnityEngine;

public class ItemMovement : MonoBehaviour, ITutorialEvent
{
    private Camera _camera;
    private PointHandler _pointHandler;
    private UpgradeHandler _upgradeHandler;
    private bool _isDragged = false;
    private Vector3 _mousePos;
    private SpawnPoint _newPoint;

    public event Action Performed;

    private SpawnPoint PreviousPoint => _pointHandler.PreviousPoint;

    private void Start()
    {
        _camera = Camera.main;
        _pointHandler = GetComponent<PointHandler>();
        TryGetComponent(out _upgradeHandler);
    }

    private void Update()
    {
        if (_isDragged)
        {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;

            transform.position = _mousePos;
        }
    }

    private void OnMouseDown()
    {
        _isDragged = true;
        _newPoint = _pointHandler.PreviousPoint;

        if (_upgradeHandler != null)
            _upgradeHandler.enabled = true;
    }

    private void OnMouseUp()
    {
        _isDragged = false;

        transform.position = PreviousPoint.transform.position;
        Rotate();

        if (_newPoint != PreviousPoint)
            Performed?.Invoke();
    }

    private void Rotate()
    {
        Vector3 rotation = new(0, 0, 90);
        transform.rotation *= Quaternion.Euler(rotation);
    }
}