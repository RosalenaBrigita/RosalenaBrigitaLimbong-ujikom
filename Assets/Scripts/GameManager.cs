using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f;
    private float currentTime = 0f;
    private bool isGameOver = false;
    public TextMeshProUGUI timerText;
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public GameObject gameOver;
    public GameObject pauseMenuUI; 

    void Start()
    {
        currentTime = 0f;
        isGameOver = false;
        if (camera1 != null) camera1.Priority = 1;
        if (camera2 != null) camera2.Priority = 0;
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            currentTime += Time.deltaTime;
            float remainingTime = gameDuration - currentTime;
            remainingTime = Mathf.Max(remainingTime, 0f);
            UpdateTimerText(remainingTime);

            if (currentTime >= gameDuration)
            {
                GameOver();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGameOver)
            {
                PauseGame();
            }
        }
    }

    void UpdateTimerText(float time)
    {
        if (timerText != null)
        {
            string formattedTime = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
            timerText.text = "Time: " + formattedTime;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        isGameOver = true;

        if (camera1 != null) camera1.Priority = 0;
        if (camera2 != null) camera2.Priority = 1;
        gameOver.SetActive(true);
    }

    void PauseGame()
    {
        Time.timeScale = 0f; 
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
