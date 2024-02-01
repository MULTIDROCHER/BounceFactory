using System;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(PointHandler))]
    [RequireComponent(typeof(UpgradeHandler))]
    public class ItemMover : MonoBehaviour, ITutorialEvent
    {
        private Camera _camera;
        private PointHandler _pointHandler;
        private UpgradeHandler _upgradeHandler;
        private Vector3 _mousePos;
        private SpawnPoint _newPoint;
        private Vector3 _rotation = new(0, 0, 90);

        public event Action Performed;

        public bool IsDragging { get; private set; } = false;
        private SpawnPoint PreviousPoint => _pointHandler.PreviousPoint;

        private void Start()
        {
            _camera = Camera.main;

            _pointHandler = GetComponent<PointHandler>();
            _upgradeHandler = GetComponent<UpgradeHandler>();
        }

        private void Update()
        {
            if (IsDragging)
            {
                _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                _mousePos.z = 0;

                transform.position = _mousePos;
            }
        }

        public void OnStartMovement()
        {
            IsDragging = true;
            _newPoint = _pointHandler.PreviousPoint;

            if (_upgradeHandler != null)
                _upgradeHandler.enabled = true;
        }

        public void OnEndMovement()
        {
            IsDragging = false;

            transform.position = PreviousPoint.transform.position;
            Rotate();

            if (_newPoint != PreviousPoint)
                Performed?.Invoke();
        }

        private void Rotate() => transform.rotation *= Quaternion.Euler(_rotation);
    }
}