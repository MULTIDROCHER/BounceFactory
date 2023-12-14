using System;
using UnityEngine;

public class FlipperController : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private Flipper _flipper;
    [SerializeField] private KeyCode _key;

    public event Action Performed;

    public KeyCode Key => _key;

    private void OnMouseDown() => OpenFlipper();

    private void Update()
    {
        if (Input.GetKeyDown(_key))
            OpenFlipper();
    }

    private void OpenFlipper()
    {
        Performed?.Invoke();
        _flipper.Open();
    }
}