using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public float musicVolume = 1f;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = musicVolume;
        audioSource.volume = musicVolume;
        audioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");

    }

    private void Update()
    {

        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void VolumeUpdater(float volume)
    {
        musicVolume = volume;
    }

}
