using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource[] musicSources;
    [SerializeField] AudioSource[] sfxSources;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public void ChangeMusicVolume()
    {
        ChangeVolume(musicSources, musicSlider);
    }

    public void ChangeSFXVolume()
    {
        ChangeVolume(sfxSources, sfxSlider);
    }

    public void ChangeVolume(AudioSource[] source, Slider slider)
    {
        for (int i = 0; i < source.Length; i++)
        {
            source[i].volume = slider.value;
        }
    }
}
