using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCanvasManager : MonoBehaviour
{
    public GameObject hudmenu;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;

    public Text fpsText;

    private int lastFrameIndex;
    private float[] frameDeltaTimeArray;
    private bool isGamePaused;




    private void Awake()
    {
        frameDeltaTimeArray = new float[100];

        if (GameManager.Instance.isFPSTextActive)
        {
            Debug.Log(GameManager.Instance.isFPSTextActive);
            fpsText.gameObject.SetActive(true);
        }

        else
        {
            fpsText.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
        lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;

        fpsText.text = "FPS: " + Mathf.RoundToInt(CalculateFPS()).ToString();

        PauseMenu();
    }

    public void ShowGameOverMenu()
    {
        hudmenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void ReturnToBase()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public float CalculateFPS()
    {
        float total = 0f;

        foreach (float deltaTime in frameDeltaTimeArray)
        {
            total += deltaTime;
        }

        return frameDeltaTimeArray.Length / total;
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
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
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
