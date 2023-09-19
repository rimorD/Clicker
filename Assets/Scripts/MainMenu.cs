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
        scoreBoard.enabled = false;

        // Test
        Dictionary<string, int> test = new Dictionary<string, int>();
        test.Add("Cristina", 50);
        test.Add("David", 45);
        test.Add("Laura", 32);
        test.Add("Carlos", 14);
        test.Add("Alex", 4);
        PlayerPrefs.SetString("highscore", JsonConvert.SerializeObject(test));

        LoadRecords();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Button actions /////////////////////////////////////////////////////////////////////////////

    public void NewGame()
    {
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

        // Convert to dictionary
        topscores = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

        // Empty textbox and start index
        top.text = "";
        int index = 1;

        // Iterate names and add new line (if any highscores)
        // We assume the highscores are ordered
        foreach(string name in topscores.Keys)
        {
            top.text += string.Format("{0}- {1} ({2})\n", index, name, topscores[name]);
            index++;
        }
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    public Canvas scoreBoard;
    public Text top;

    private Dictionary<string, int> topscores = new Dictionary<string, int>();
}
