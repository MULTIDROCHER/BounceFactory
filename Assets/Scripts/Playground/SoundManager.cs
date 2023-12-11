using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    public static SoundManager Instance;

    public AudioSource MusicSource => _musicSource;
    public AudioSource SFXSource => _sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchSource(AudioSource source, SoundButton button)
    {
        Debug.Log(source.volume);
        
        if (source.volume == 0)
            Unmute(source, button);
        else
            Mute(source, button);
    }

    private void Mute(AudioSource source, SoundButton button)
    {
        source.volume = 0;
        button.Mute();
    }

    private void Unmute(AudioSource source, SoundButton button)
    {
        source.volume = 1;
        button.Unmute();
    }
}
