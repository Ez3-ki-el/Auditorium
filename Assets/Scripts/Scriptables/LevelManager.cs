
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "new " + nameof(LevelManager), menuName = nameof(LevelManager))]
public class LevelManager : ScriptableObject
{

    public void UpLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);
    }


}
