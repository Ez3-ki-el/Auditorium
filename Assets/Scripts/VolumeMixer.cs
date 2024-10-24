using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetVolume(float value)
    {
        var decibel = Mathf.Log10(value) * 20f;
        mixer.SetFloat("MasterVolume", decibel);
    }
}
