using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will save options about music, sfx, particles?
public class OptionSave : MonoBehaviour
{
    public static OptionSave Instance;
    private float volomeSFX = 1;
    public float VolumeSF => volomeSFX;
    private float musicVolume = 1;
    public float MusicVolume => musicVolume;
    public Action<float> onMusicVolumeChanged;
    public Action<float> onSFXVolumeChanged;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeSFXVolume(float value)
    {
        volomeSFX = value;
        onSFXVolumeChanged?.Invoke(volomeSFX);
    }
    public void ChangeMusicVolume(float value)
    {
        musicVolume = value;
        onMusicVolumeChanged?.Invoke(musicVolume);
    }
}
