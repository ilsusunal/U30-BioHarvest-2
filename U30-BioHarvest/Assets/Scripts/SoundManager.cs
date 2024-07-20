using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource; 

    public Slider musicSlider; 
    public Slider sfxSlider;

    void Start()
    {
        // Slider'lar�n ba�lang�� de�erlerini ayarlama
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;

        // Slider'lara event ekleme
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    // M�zik ses d�zeyi
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Ses efektleri d�zeyi
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    public void PlayWalkingSound()
    {
        Debug.Log("Playing walking sound.");
        sfxSource.Play();
    }
}
