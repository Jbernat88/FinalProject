using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{

    public Volume volume;
    
    public PlayerController PlayerController;

    //Start is called before the first frame update
    void Update()
    {
        

        Bloom bloom;
        ChromaticAberration chromatic;
        DepthOfField depth;
        LensDistortion distortion;

        if(volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.intensity.value = 100;
        }

        if (volume.profile.TryGet<ChromaticAberration>(out chromatic))
        {
            
            chromatic.intensity.value = PlayerController.chromaticAb;
        }

        if (volume.profile.TryGet<DepthOfField>(out depth))
        {
            depth.focalLength.value = PlayerController.depthField;
        }

        if (volume.profile.TryGet<LensDistortion>(out distortion))
        {
            distortion.intensity.value = PlayerController.lensDistortion;
        }
    }

}
