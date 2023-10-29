using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject player1;
    public GameObject player2;


    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        PlayerOne pm = player1.GetComponent<PlayerOne>();
        PlayerTwo pm2 = player2.GetComponent<PlayerTwo>();
        PlayerOneAttack at = player1.GetComponent<PlayerOneAttack>();
        PlayerTwoAttack at2 = player2.GetComponent<PlayerTwoAttack>();

        pm.enabled = false;
        pm2.enabled = false;
        at.enabled = false;
        at2.enabled = false;

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        PlayerOne pm = player1.GetComponent<PlayerOne>();
        PlayerTwo pm2 = player2.GetComponent<PlayerTwo>();
        PlayerOneAttack at = player1.GetComponent<PlayerOneAttack>();
        PlayerTwoAttack at2 = player2.GetComponent<PlayerTwoAttack>();

        pm.enabled = true;
        pm2.enabled = true; 
        at.enabled = true;
        at2.enabled = true;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void BackToMenuFromAI()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
