using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    private GameObject[] panelsMode;

    public const string GameMode = "Game";
    public const string BuildMode = "Build";

    // Use this for initialization
    void Start()
    {
        panelsMode = GameObject.FindGameObjectsWithTag("Panel");

        DisableAllModeExcept("Game");

    }

    public void EnableBuildMode()
    {
        DisableAllModeExcept(BuildMode);
        EnablePanel("Build Panel");
    }

    public void EnableGameMode()
    {
        DisableAllModeExcept(GameMode);
        EnablePanel("Game Panel");
    }

    private void EnablePanel(string panelToEnable)
    {
        for (int i = 0; i < panelsMode.Length; i++)
        {
            if (panelsMode[i].name == panelToEnable)
                panelsMode[i].SetActive(true);
        }
    }

    private void DisableAllModeExcept(string modeToExcept = "nothing")
    {
        for (int i = 0; i < panelsMode.Length; i++)
        {
            if (panelsMode[i].name.Contains(modeToExcept))
                continue;
            panelsMode[i].SetActive(false);
        }
    }
}
