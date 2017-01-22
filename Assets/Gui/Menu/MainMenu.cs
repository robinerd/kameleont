using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public AudioSource musicBackground;
	public Text textLoading;
	private Boolean isLoading = false;

    public Text textHighScore;
    private Boolean isSaving = false;

    public bool isGameOverScreen;
    public Text scorevalue;
    public Text HighScorePlayers;

    void Start ()
	{


	    int s = Score.score;
        if (scorevalue != null)
            scorevalue.text = s.ToString();

	    if (!isGameOverScreen)
	    {
	        ReadHighScore(); //Displays best of 5 players
	    }
    }
	// Update is called once per frame
	void Update () {

        //if (!isLoading && Input.GetButton("StartGameButton"))
        //{
        //	StartGame();
        //}


	    if (!isGameOverScreen)
	    {
	        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
	        {
	            ButtonStartGame();
	        }
	    }
	    else if (Input.GetButtonDown("GoToMainMenu"))
	    {
	        SceneManager.LoadScene("MainMenu");
	    }
	}

    private void ReadHighScore()
    {
        try
        {
            List<HighScorePerson> listPersons = new List<HighScorePerson>();
            string[] scoreTexts = File.ReadAllLines("playerprogress/highscores.txt");
            if (HighScorePlayers)
            {
                HighScorePlayers.text = "";
                foreach (string line in scoreTexts)
                {
                    string scoreStr = "";
                    int i = 0;
                    for (i = 0; i < line.Length; i++)
                    {
                        if (line[i] != '#')
                        {
                            scoreStr += line[i];
                        }
                        else
                        {
                            i++;
                            HighScorePerson person = new HighScorePerson();
                            int.TryParse(scoreStr, out person.scoreNr);
                            string scoreName = "";
                            for (i = i; i < line.Length; i++)
                            {
                                scoreName += line[i];
                            }
                            person.Name = scoreName;
                            listPersons.Add(person);
                            break;
                        }
                    }
                }
                listPersons = sortListByNumber(listPersons); //Sorting!

                int maxRead = listPersons.Count;
                if (maxRead > 6)
                    maxRead = 6;

                HighScorePlayers.text = "";
                for (int j = 0; j < maxRead; j++)
                {
                    HighScorePlayers.text += listPersons[j].scoreNr + "" + listPersons[j].Name + "\n";
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Reading highscores: " + e);
        }
    }

    private List<HighScorePerson> sortListByNumber(List<HighScorePerson> listPeople)
    {
        HighScorePerson t;
        for (int j = 0; j <= listPeople.Count - 2; j++)
        {
            for (int i = 0; i <= listPeople.Count - 2; i++)
            {
                if (listPeople[i].scoreNr < listPeople[i + 1].scoreNr)
                {
                    t = listPeople[i + 1];
                    listPeople[i + 1] = listPeople[i];
                    listPeople[i] = t;
                }
            }
        }
        return listPeople;
    }

    public void ButtonStartGame()
    {
        textLoading.text = "Loading!";
        SceneManager.LoadScene("Ingame");
        isLoading = true;
    }

    public void ButtonCredits()
    {
        
    }

    public void ButtonHighScores()
	{
		SceneManager.LoadScene("HighScoreMenu");
	}

	public void ButtonQuit()
	{
		Application.Quit();
	}
}