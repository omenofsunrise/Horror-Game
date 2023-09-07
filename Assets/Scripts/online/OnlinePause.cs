using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnlinePause : MonoBehaviour
{
    public bool PauseGame = false;
    public GameObject pauseGameMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        PauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        PauseGame = true;
    }

    public void LoadMenu()
    {
  
        SceneManager.LoadScene("Menu");
    }
}
