using Agava.WebUtility;
using UnityEngine;

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

    private void OnEnable() => WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

    private void OnDisable() => WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }
}