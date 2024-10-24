

using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEditor.SearchService;

using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "Scène level manager", menuName = "Scene Data/Scene Level Manager")]
public class LevelManager : ScriptableObject
{

    public List<LevelScene> levels = new();
    public LevelScene UIScene;
    public int CurrentLevelIndex = 1;

    public LevelScene currentScene => levels[CurrentLevelIndex];

    public void LoadLevelWithIndex(int index)
    {
        if (index <= levels.Count)
        {
            Object scene = levels[CurrentLevelIndex - 1].scene;

#if UNITY_EDITOR
            if (scene is not SceneAsset)
                throw new System.ArgumentException($"Espece de gros débile, la liste de levels ne doit contenir que des objets de type SceneAsset, ce qui n'est pas le cas de {scene.name}");
#endif

            SceneManager.LoadScene(scene.name);
            LoadUI();
        }
        // reset de l'index
        else CurrentLevelIndex = 1;

    }

    public void NextLevel()
    {
        CurrentLevelIndex++;
        LoadLevelWithIndex(CurrentLevelIndex);
    }

    public void RestartLevel()
    {
        LoadLevelWithIndex(CurrentLevelIndex);
    }

    public void NewGame()
    {
        LoadLevelWithIndex(0);
    }

    public void LoadUI()
    {
#if UNITY_EDITOR
        if (UIScene != null && UIScene.scene is not SceneAsset)
            throw new System.ArgumentException($"Espece de gros débile, l'UI doit être une scene, ce qui n'est pas le cas de {UIScene.scene.name}");
#endif
        // Ajout de l'UI
        if (UIScene != null)
        {
            // Vérification qu'elle existe
            var sceneUI = SceneManager.GetSceneByName(UIScene.scene.name);
            // Vérification qu'elle est chargée
            if (!sceneUI.isLoaded)
                SceneManager.LoadScene(UIScene.scene.name, LoadSceneMode.Additive);
        }
    }

}
