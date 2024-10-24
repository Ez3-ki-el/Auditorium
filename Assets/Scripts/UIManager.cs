using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public Canvas CanvasUI;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textNiveau = CanvasUI.GetComponentInChildren<TextMeshProUGUI>();

        int numeroLevel = LevelManager.currentScene.niveau;
        textNiveau.text = "Niveau : " + numeroLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowUIVolume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            GameObject mixerRow = CanvasUI.transform.Find("MixerRow").gameObject;
            mixerRow.SetActive(!mixerRow.activeSelf);
        }
    }
}
