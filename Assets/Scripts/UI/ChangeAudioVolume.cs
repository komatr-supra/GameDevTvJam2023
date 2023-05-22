using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class ChangeAudioVolume : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
   
    public void ChangeSFXVolume() => OptionSave.Instance.ChangeSFXVolume(sfxSlider.value);
    public void ChangeMusicVolume() => OptionSave.Instance.ChangeMusicVolume(musicSlider.value);
}
