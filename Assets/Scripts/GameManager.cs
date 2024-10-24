using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] musicBoxes;
    private bool isFull;
    private float chrono = 0;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {

        musicBoxes = GameObject.FindGameObjectsWithTag("Musicbox");
        levelManager.LoadUI();
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
                levelManager.NextLevel();
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
