using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string SaveFiles;
    public GameData gameData = new GameData();

    public bool isThereSaveFile;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SaveFiles = Application.persistentDataPath + "/GameData.json"; //La localizaci�n de la carpeta donde est�n las SaveFiles
    }

    [RuntimeInitializeOnLoadMethod]
    public void LoadData()
    {
        if (File.Exists(SaveFiles))
        {
            isThereSaveFile = true;

            string content = File.ReadAllText(SaveFiles);
            Debug.Log("JSON Content: " + content);
            GameData loadedData = JsonUtility.FromJson<GameData>(content);

            //_____________________________________________________________
            gameData.isMutedBool = loadedData.isMutedBool;
            gameData.muteText = loadedData.muteText;
            gameData.muteToggleValue = loadedData.muteToggleValue;

            gameData.musicSliderValue = loadedData.musicSliderValue;
            gameData.SFXSliderValue = loadedData.SFXSliderValue;

            gameData.musicSliderValueBeforeMuting = loadedData.musicSliderValueBeforeMuting;
            gameData.SFXSliderValueBeforeMuting = loadedData.SFXSliderValueBeforeMuting;

            gameData.isThereSaveData = loadedData.isThereSaveData;



            GameManager.Instance.isMutedBool = gameData.isMutedBool;
            GameManager.Instance.mutedText = gameData.muteText;
            GameManager.Instance.mutedToggleValue = gameData.muteToggleValue;

            GameManager.Instance.musicSliderValue = gameData.musicSliderValue;
            GameManager.Instance.SFXSliderValue = gameData.SFXSliderValue;

            GameManager.Instance.musicSliderValueBeforeMuting = gameData.musicSliderValueBeforeMuting;
            GameManager.Instance.SFXSliderValueBeforeMuting = gameData.SFXSliderValueBeforeMuting;

            GameManager.Instance.isThereSaveData = gameData.isThereSaveData;

            Debug.Log("Loaded values: Music Slider Before Muting: " + GameManager.Instance.musicSliderValueBeforeMuting + ", SFX Slider Before Muting: " + GameManager.Instance.SFXSliderValueBeforeMuting);
        }
        else
        {
            Debug.Log("El archivo de guardado no existe");
        }
    }

    public void SaveData()
    {
        isThereSaveFile = true;

        GameData newData = new GameData();
        {
            newData.isMutedBool = GameManager.Instance.isMutedBool;
            newData.muteText = GameManager.Instance.mutedText;
            newData.muteToggleValue = GameManager.Instance.mutedToggleValue;

            newData.musicSliderValue = GameManager.Instance.musicSliderValue;
            newData.SFXSliderValue = GameManager.Instance.SFXSliderValue;

            newData.musicSliderValueBeforeMuting = GameManager.Instance.musicSliderValueBeforeMuting;
            newData.SFXSliderValueBeforeMuting = GameManager.Instance.SFXSliderValueBeforeMuting;

            GameManager.Instance.isThereSaveData = true;

            newData.isThereSaveData = GameManager.Instance.isThereSaveData;
        };

        string JsonString = JsonUtility.ToJson(newData, true);

        File.WriteAllText(SaveFiles, JsonString);

        Debug.Log("Saved File with values: Music Slider Before Muting: " + newData.musicSliderValueBeforeMuting + ", SFX Slider Before Muting: " + newData.SFXSliderValueBeforeMuting);

        Debug.Log("Saved File");
    }
}
