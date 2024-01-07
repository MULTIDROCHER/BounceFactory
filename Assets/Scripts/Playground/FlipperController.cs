using System;
using UnityEngine;

public class FlipperController : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private Flipper _flipper;
    [SerializeField] private KeyCode _key;

    public event Action Performed;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
            OpenFlipper();
    }

    public void OpenFlipper()
    {
        Performed?.Invoke();
        _flipper.Open();
    }
}