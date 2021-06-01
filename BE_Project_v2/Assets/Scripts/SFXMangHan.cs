using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXMangHan : MonoBehaviour {

    /** Contributed by Team Member */
    
    public AudioMixer SFXMixer;

    public Slider SFX;

    /*public void SetVolume( float volume)
    {
        SFXMixer.SetFloat("SFXParam", volume);
    }

    private void Start()
    {
        SFX.value = PlayerPrefs.GetFloat("sfxVolume", 0);
    }

    private void OnDisable()
    {
        float sfxVolume = 0;
        SFXMixer.GetFloat("SFXParam", out sfxVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }*/

    public void SetVolume(float slider_volume)
    {
        SFXMixer.SetFloat("SFXParam", ConvertToDecibel(slider_volume));
        PlayerPrefs.SetFloat("sfxVolume", slider_volume);
    }

    private void Start()
    {
        SFX.value = PlayerPrefs.GetFloat("sfxVolume", 0.75f);
    }

    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }
}
