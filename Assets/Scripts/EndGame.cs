using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        title.text = string.Format(title.text, level);

        asrc.PlayOneShot(deathClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //---------------------------------------------------------------------------------------------

    public void SaveRecord()
    {
        string playerName = input.text;

        // Nothing written
        if (playerName.Length <= 0)
            return;

        // Get previous records
        // Get high scores from player prefs in json format
        string json = PlayerPrefs.GetString("highscore");

        // Convert to list
        List<KeyValuePair<int, string>> topscores = JsonConvert.DeserializeObject<List<KeyValuePair<int, string>>>(json);

        // Add our score and sort the list
        topscores.Add(new KeyValuePair<int, string>(level, playerName));
        topscores.Sort((KeyValuePair<int, string> a, KeyValuePair<int, string> b) => b.Key - a.Key);

        // Delete lowest scores if more than 5
        if (topscores.Count > 5)
        {
            for (int i = topscores.Count - 1; i >= 5; i--)
            {
                topscores.RemoveAt(i);
            }
        }

        // Save top score
        PlayerPrefs.SetString("highscore", JsonConvert.SerializeObject(topscores));

        // Return to main menu
        SceneManager.LoadScene("MenuScene");
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]TMP_InputField input;
    [SerializeField]TextMeshProUGUI title;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioSource asrc;
    int level;
}
