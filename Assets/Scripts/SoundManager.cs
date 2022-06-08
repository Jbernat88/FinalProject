using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audios;

    private AudioSource controlAudio;
    

    // Start is called before the first frame update
    public void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void SeleccionAudio(int indice, float volume)
    {
        controlAudio.PlayOneShot(audios[indice], volume);
    }
}
