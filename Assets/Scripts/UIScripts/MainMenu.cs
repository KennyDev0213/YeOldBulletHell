using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetSceneByName("Prototype").path); //I want to find a way to just look for scenes with name
        SceneManager.LoadScene(1);
    }

    public void Leave()
    {
        Debug.Log("Leaving the Game");
        Application.Quit();
    }
}
