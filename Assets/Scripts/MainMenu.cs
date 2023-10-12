using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hide scoreboard screen
        scoreBoard.enabled = false;

        // Load previous records
        LoadRecords();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Button actions /////////////////////////////////////////////////////////////////////////////

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("GameplayScene");
    }

    //---------------------------------------------------------------------------------------------

    public void ShowRecords()
    {
        scoreBoard.enabled = true;
    }

    //---------------------------------------------------------------------------------------------

    public void HideRecords()
    {
        scoreBoard.enabled = false;
    }

    //---------------------------------------------------------------------------------------------

    public void ExitGame()
    {
        Application.Quit();
    }

    //---------------------------------------------------------------------------------------------

    public void LoadRecords()
    {
        // Get high scores from player prefs in json format
        string json = PlayerPrefs.GetString("highscore");

        // Convert to list
        topscores = JsonConvert.DeserializeObject<List<KeyValuePair<int, string>>>(json);

        // Empty textbox and start index
        top.text = "";
        int index = 1;

        // Iterate names and add new line (if any highscores)
        // We assume the highscores are ordered
        foreach(KeyValuePair<int, string> score in topscores)
        {
            top.text += string.Format("{0}- {1} ({2})\n", index, score.Value, score.Key);
            index++;
        }
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    public Canvas scoreBoard;
    public Text top;

    private List<KeyValuePair<int, string>> topscores = new List<KeyValuePair<int, string>>();
}
