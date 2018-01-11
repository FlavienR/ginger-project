using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class GUIManager : MonoBehaviour
{
    // Static singleton instance
    private static GUIManager _instance;

    // Static singleton property
    public static GUIManager Instance
    {
        get { return _instance ?? (_instance = new GameObject("Canvas").AddComponent<GUIManager>()); }
    }

    [SerializeField]
    private GameObject[] _panels;

    private const string GAME_MODE = "Game";
    private const string BUILD_MODE = "Build";
    private const string VALID_BUILDING_MODE = "Validation";

    public void ValidateBuilding()
    {
        EnableBuildMode();
        GameManager.Instance.ValidateBuilding();
    }

    public void CancelBuilding()
    {
        EnableBuildMode();
        GameManager.Instance.CancelBuilding();
    }

    public void OnClickTurret()
    {
        EnablePanel("Validation Panel");
        GameManager.Instance.ClickTurret();
    }

    public void OnClickWoodPlanks()
    {
        EnablePanel("Validation Panel");
        GameManager.Instance.ClickWoodPlanks();
    }

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
        for (int i = 0; i < _panels.Length; i++)
        {
            if (_panels[i].name == panelToEnable)
                _panels[i].SetActive(true);
        }
    }

    private void DisableAllModeExcept(string modeToExcept = "nothing")
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            if (_panels[i].name.Contains(modeToExcept))
                continue;
            _panels[i].SetActive(false);
        }
    }

    // Use this for initialization
    private void Start()
    {
        _panels = GameObject.FindGameObjectsWithTag("Panel");
        DisableAllModeExcept(GAME_MODE);
    }
}
