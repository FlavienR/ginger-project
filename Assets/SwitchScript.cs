using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    private GameObject[] panelsMode;
    private const string GAME_MODE = "Game";
    private const string BUILD_MODE = "Build";

    public void EnableBuildMode()
    {
        DisableAllModeExcept(BUILD_MODE);
        EnablePanel("Build Panel");
    }

    public void EnableGameMode()
    {
        DisableAllModeExcept(GAME_MODE);
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

    // Use this for initialization
    private void Start()
    {
        panelsMode = GameObject.FindGameObjectsWithTag("Panel");
        DisableAllModeExcept("Game");
    }
}
