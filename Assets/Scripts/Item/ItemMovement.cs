using UnityEngine;
using UnityEngine.Events;

public class ItemMovement : MonoBehaviour
{
    private Camera _camera;
    private ItemCollisionHandler _collisionHandler;
    private bool _isDragged = false;
    private Vector3 _mousePos;
    private SpawnPoint _prevPoint;

    private void Start()
    {
        _camera = Camera.main;
        _collisionHandler = GetComponent<ItemCollisionHandler>();

        _prevPoint = _collisionHandler.GetPoint();
    }

    private void Update()
    {
        if (_isDragged)
        {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;
        }
    }

    private void OnMouseDown()
    {
        _isDragged = true;
    }

    private void OnMouseDrag()
    {
        if (_isDragged)
            transform.position = _mousePos;
    }

    private void OnMouseUp()
    {
        _isDragged = false;

        _prevPoint = _collisionHandler.PreviousPoint;
        transform.position = _prevPoint.transform.position;
        Rotate();
    }

    private void Rotate()
    {
        Vector3 rotation = new(0, 0, 90);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotation);
    }
}