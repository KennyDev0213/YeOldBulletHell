using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Leave()
    {
        //SceneManager.LoadScene(SceneManager.GetSceneByName("MainMenu").path);
        SceneManager.LoadScene(0);
        Time.timeScale = 1; //timescale does not reset when switching scenes
    }

}
