using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(Image))]
public class FlipperActivator : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private Flipper _flipper;
    [SerializeField] private KeyCode _key;

    public KeyCode KeyCode => _key;

    public event Action Performed;

    private void Awake()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            var image = GetComponent<Image>();
            image.color = new(1, 1, 1, 0);
        }
    }

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