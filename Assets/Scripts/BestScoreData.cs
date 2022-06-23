using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BestScoreData : MonoBehaviour
{
    public static BestScoreData Instance;
    public string playerName;
    public int score;
    public string champion;
    public TMP_InputField playerInputField;
    [SerializeField] private Button startButton;
    // Start is called before the first frame update

    [System.Serializable]
    class SaveData
    {
        public string champion;
        public int score;
    }
    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    void Start()
    {
    
        startButton.onClick.AddListener(SetPlayerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerName()
    {
        Debug.Log("llama a la función");
        if (playerInputField.text != "")
        {
            playerName = playerInputField.text;
        }
        else {
            playerName = "player1";
        }
        Debug.Log(playerName);
        SceneManager.LoadScene("main");
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            champion = data.champion;
            score = data.score;
            Debug.Log("Champion: " + champion + " score: " + score);
        }
        else {
            champion = "";
            score = 0;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.champion = champion;
        data.score = score;

        string Json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", Json);
    }
}
