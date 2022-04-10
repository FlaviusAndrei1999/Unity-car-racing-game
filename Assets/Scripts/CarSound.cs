using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    AudioSource audioClip;
    public float minPitch;
    private float pitchFromCar;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        audioClip.pitch = minPitch;


        
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = player.script.carCurentSpeed;
        if (pitchFromCar < minPitch)
        {
            audioClip.pitch = minPitch;
        }
        else
        {
            audioClip.pitch = pitchFromCar;
        }
        if (PauseMenu.GameisActive)
        {
            audioClip.pitch = 0f;
        }


        
    }
}
