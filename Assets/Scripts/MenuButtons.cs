using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("PhysicsLecture");
        //SceneManager.LoadSceneAsync("PhysicsLecture");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ReturnToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
