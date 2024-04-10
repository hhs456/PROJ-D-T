using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider seVolumeSlider;
    void Start()
    {
        float masterValue;
        float bgmValue;
        float seValue;
        //get Master, BGM, SE's volume from mixer first.
        audioMixer.GetFloat("MasterVolume", out masterValue);
        audioMixer.GetFloat("BgmVolume", out bgmValue);
        audioMixer.GetFloat("SoundEffectVolume", out seValue);

        masterVolumeSlider.value = masterValue;
        bgmVolumeSlider.value = bgmValue;
        seVolumeSlider.value = seValue;
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetBgmVolume(float volume)
    {
        audioMixer.SetFloat("BgmVolume", volume);
    }
    public void SetSoundEffectVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffectVolume", volume);
    }
    public void ExitVolumeAdjust()
    {
        FindAnyObjectByType<SceneController>().DestroyAudioMenu();
    }
}
