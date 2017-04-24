using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickScript : MonoBehaviour
{
    // Update is called once per frame
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
