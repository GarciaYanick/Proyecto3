using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> EasyLevels = new List<GameObject>();
    public List<GameObject> MidLevels = new List<GameObject>();
    public List<GameObject> DifLevels = new List<GameObject>();
    public List<GameObject> BossLevels = new List<GameObject>();

    public int currentLevel = 1;

    public bool isMutedBool = false;
    public Text mutedText;
    public bool mutedToggleValue = false;
    public float musicSliderValue;
    public float SFXSliderValue;

    public bool isFrameTextActive;

    public WinCanvasManager canvasManager;


    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DataManager.instance.LoadData();
        LevelChange();
    }

    void Start()
    {
        //LevelChange();
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
    }
    public void LevelChange()
    {
        switch (currentLevel)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                Instantiate(EasyLevels[Random.Range(0, EasyLevels.Count)]);
                //EasyLevels[Random.Range(0, EasyLevels.Count)].SetActive(true);
                break;
            case 5:
                Instantiate(BossLevels[Random.Range(0, BossLevels.Count)]);
                //BossLevels[Random.Range(0, BossLevels.Count)].SetActive(true);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
                Instantiate(MidLevels[Random.Range(0, MidLevels.Count)]);
                //MidLevels[Random.Range(0, MidLevels.Count)].SetActive(true);
                break;
            case 10:
                Instantiate(BossLevels[Random.Range(0, BossLevels.Count)]);
                //BossLevels[Random.Range(0, BossLevels.Count)].SetActive(true);
                break;
            case 11:
            case 12:
            case 13:
            case 14:
                Instantiate(DifLevels[Random.Range(0, DifLevels.Count)]);
                ///DifLevels[Random.Range(0, DifLevels.Count)].SetActive(true);
                break;
            case 15:
                Instantiate(BossLevels[Random.Range(0, BossLevels.Count)]);
                //BossLevels[Random.Range(0, BossLevels.Count)].SetActive(true);
                break;
            case 16:
                SceneManager.LoadScene("Win");
                break;
        }
    }
    public void SetGameOver()
    {
        canvasManager.ShowGameOverMenu();
    }
}
