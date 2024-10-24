using UnityEngine;


[CreateAssetMenu(fileName = "Sc�ne level", menuName = "Scene Data/Scene Level")]
public class LevelScene : ScriptableObject
{
    [Header("Informations")]
    public string description;
    public int niveau;

    [Header("Sc�ne de type SceneAsset")]
    public Object scene;
    // Start is called before the first frame update
}
