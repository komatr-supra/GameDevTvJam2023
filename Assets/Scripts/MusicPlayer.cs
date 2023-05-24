using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is attached to camera for play a music all the time
public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer Instance;
    [SerializeField] private AudioClip[] lightAudios;
    [SerializeField] private AudioClip[] darkAudios;
    private AudioSource audioSource;
    private bool isLightDimension = true;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //subscribe volume change
        OptionSave.Instance.onMusicVolumeChanged += MusicVolumeChanged_OptionSave;
        PlayRandomMusic();
    }
    private void OnDestroy()
    {
        OptionSave.Instance.onMusicVolumeChanged -= MusicVolumeChanged_OptionSave;
    }
    private void Update()
    {
        if (audioSource.isPlaying) return;

        //play new music based on environment
        PlayRandomMusic();
    }
    private void PlayRandomMusic()
    {
        var newAudioClips = isLightDimension ? lightAudios : darkAudios;
        var audio = newAudioClips[Random.Range(0, newAudioClips.Length)];
        Debug.Log(audio);
        audioSource.PlayOneShot(audio, OptionSave.Instance.MusicVolume);
    }
    private void MusicVolumeChanged_OptionSave(float volume)
    {
        audioSource.volume = volume;
    }

}
