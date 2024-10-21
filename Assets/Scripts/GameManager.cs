using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] musicBoxes;
    private bool isFull;
    private float chrono=0;

    // Start is called before the first frame update
    void Start()
    {

        musicBoxes = GameObject.FindGameObjectsWithTag("Musicbox");
   
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var musicBox in musicBoxes)
        {
            isFull = isFull || GetVolume(musicBox) >= 1;
        }

        if (isFull)
        {
            if (chrono > 2f)
            {
                Debug.Log("WIN");
            }
            else
            {
                chrono += Time.deltaTime;
            }
        }
        else
        {
            chrono = 0;
        }
    }


    private static float GetVolume(GameObject musicbox)
    {
        return musicbox.GetComponent<AudioSource>().volume;
    }
}
