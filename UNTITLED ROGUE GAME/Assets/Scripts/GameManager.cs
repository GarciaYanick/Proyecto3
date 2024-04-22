using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public List<GameObject> EasyLevels = new List<GameObject>();
   public List<GameObject> MidLevels = new List<GameObject>();
   public List<GameObject> DifLevels = new List<GameObject>();
   public List<GameObject> BossLevels = new List<GameObject>();

   public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
       LevelChange();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
        musicSource.volume = 0.35f;

    }
    public void LevelChange()
    {
        switch (currentLevel)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                EasyLevels[Random.Range(0, EasyLevels.Count)].SetActive(true);
                break;
            case 5:
                BossLevels[Random.Range(0, BossLevels.Count)].SetActive(true);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
                MidLevels[Random.Range(0, MidLevels.Count)].SetActive(true);
                break;
            case 10:
                BossLevels[Random.Range(0, BossLevels.Count)].SetActive(true);
                break;
            case 11:
            case 12:
            case 13:
            case 14:
                DifLevels[Random.Range(0, DifLevels.Count)].SetActive(true);
                break;
            case 15:
                BossLevels[Random.Range(0, BossLevels.Count)].SetActive(true);
                break;
        }
    }
}
