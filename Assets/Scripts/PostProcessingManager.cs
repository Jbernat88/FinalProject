using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{

    public Volume volume;
    //public float chromaticValue;
    //public PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        //chromaticValue = PlayerController.ChromaticAb;

        Bloom bloom;
        //ChromaticAberration chromatic;

        if(volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.intensity.value = 100;
        }

        //if (volume.profile.TryGet<ChromaticAberration>(out chromatic))
        //{
        //    chromatic.intensity.value = chromaticValue;
        //}

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //bloom.intensity.vlaue = Mathf.PingPong(Time.time * 6, 8f);
        //chromatic.intensity.value = Mathf.PingPong(Time.time * 6, 1f);
    }
}
