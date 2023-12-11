using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundableButton : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private AudioSource _source;
    private Button _button;

    private void Start()
    {
        _source = SoundManager.Instance.SFXSource;
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => PlaySound());
    }

    //public void OnPointerDown(PointerEventData eventData) => PlaySound();

    private void PlaySound() => _source.PlayOneShot(_clip);
}
