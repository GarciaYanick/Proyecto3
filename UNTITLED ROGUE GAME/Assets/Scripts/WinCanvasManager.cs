using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TopDownCharacter2D.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCanvasManager : MonoBehaviour
{
    public GameObject hudmenu;
    public GameObject gameOverMenu;
    public GameObject inventoryMenu;
    public Text coinsText;

    public Text fpsText;

    private int lastFrameIndex;
    private float[] frameDeltaTimeArray;


    private void Awake()
    {
        frameDeltaTimeArray = new float[100];

        if (GameManager.Instance.isFrameTextActive)
        {

            Debug.Log(GameManager.Instance.isFrameTextActive);
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

        fpsText.text = Mathf.RoundToInt(CalculateFPS()).ToString();
    }
    private void FixedUpdate()
    {

        SetMoney();
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
    public void OpenInventory()
    {
        Time.timeScale = 0f;
        hudmenu.SetActive(false);
        inventoryMenu.SetActive(true);
    }
    public void SetMoney()
    {
        var player = GameObject.Find("Player").GetComponent<CharacterStatsHandler>();
        coinsText.text=  player.money.ToString();
    }
    public void ReturnToGame()
    {
        inventoryMenu.SetActive(false);
        Time.timeScale = 1.0f;
        hudmenu.SetActive(true );
    }
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
