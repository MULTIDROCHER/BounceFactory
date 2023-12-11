using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundableObject : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private AudioClip _clip;

    private AudioSource _source;

    private void Start()
    {
        _source = SoundManager.Instance.SFXSource;
        //if (_clip == null)
            //_clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sound/click.mp3");
    }

    private void OnMouseDown() => PlaySound();

    public void OnPointerDown(PointerEventData eventData) => PlaySound();

    private void PlaySound() =>_source.PlayOneShot(_clip);
}
