using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SFXPlayer
{
    public static void PlaySFX(Vector3 position, AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, position, OptionSave.Instance.VolumeSF);
    }
}
