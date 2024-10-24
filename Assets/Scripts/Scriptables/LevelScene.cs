using UnityEngine;


[CreateAssetMenu(fileName = "Scène level", menuName = "Scene Data/Scene Level")]
public class LevelScene : ScriptableObject
{
    [Header("Informations")]
    public string description;
    public int niveau;

    [Header("Scène de type SceneAsset")]
    public Object scene;
    // Start is called before the first frame update
}
