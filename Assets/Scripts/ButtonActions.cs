using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public TMP_InputField playerInputField;
    // Start is called before the first frame update
    void Start()
    {
        
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
            BestScoreData.Instance.playerName = playerInputField.text;
        }
        else
        {
            BestScoreData.Instance.playerName = "player1";
        }
        Debug.Log(BestScoreData.Instance.playerName);
        SceneManager.LoadScene("main");
    }
}
