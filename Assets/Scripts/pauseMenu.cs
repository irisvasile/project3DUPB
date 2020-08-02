using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour
{
    public static  bool GameIsPaused = false;
    // Update is called once per frame
    public GameObject pauseMenuUI;
    private LoadingScreenControl lsc;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();

            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");
        //gamemanagerscript.instance.LoadGame();
        //LoadingScreenControl.instance.LoadScreenExample(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);        //lsc.LoadScreenExample(1);
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}

