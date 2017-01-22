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
    private List<HighScorePerson> listHighScore;
    private Boolean isSaving = false;

    public bool isGameOverScreen;
    public Text scorevalue;

    void Start ()
	{
        //initHighScore();

        listHighScore = new List<HighScorePerson>();
        //readHighScoreFile();

	    int s = Score.score;
        if (scorevalue != null)
            scorevalue.text = s.ToString();

    }

	// Update is called once per frame
	void Update () {

        //if (!isLoading && Input.GetButton("StartGameButton"))
        //{
        //	StartGame();
        //}


        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter") || Input.GetKeyDown("return") || Input.GetButtonDown("GoToMainMenu"))
        {
            if (!isGameOverScreen)
                ButtonStartGame();
            else
                SceneManager.LoadScene("MainMenu");
        }
	}

	

	private void initHighScore()
	{
		//Debug.Log("file: " + File.Exists("playerprogress/highscores.txt"));
		if (!Directory.Exists("playerprogress"))
		{
			Directory.CreateDirectory("playerprogress");
		}

		if (!File.Exists("playerprogress/highscores.txt"))
		{
			File.Create("playerprogress/highscores.txt");
		}
		//string highscore = File.ReadAllText("playerprogress/highscores.txt");
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

    private void readHighScoreFile()
    {

        StreamReader stream = File.OpenText("playerprogress" +
            "/highscores.txt");
        textHighScore.text = "";
        int index = 0;
        while (!stream.EndOfStream)
        {
            index = 0;
            string line = stream.ReadLine();
            //Debug.Log("line: " + line);
            if (line == null)
                break;

            string scoreTxt = "";
            string nameTxt = "";
            while (index < line.Length && line[index] != ' ')
            {
                scoreTxt += line[index];
                index++;
            }
            index += 2;
            while (index < line.Length)
            {
                nameTxt += line[index];
                index++;
            }

            try
            {
                float scoreNr;
                float.TryParse(scoreTxt, out scoreNr);

                HighScorePerson highScorePerson = new HighScorePerson(nameTxt, scoreNr);
                listHighScore.Add(highScorePerson);
            }
            catch (Exception e)
            {
                Debug.Log("Exception MenuHighScore: " + e.ToString());
            }
        }

        if (listHighScore.Count > 0)
        {
            textHighScore.text = "";
            listHighScore = listHighScore.OrderBy(o => o.scoreNr).ToList(); //Amaaaziiiing
            int nr = 1;
            foreach (var person in listHighScore)
            {
                string s = "s";
                if (person.scoreNr > 59)
                {
                    person.scoreNr = person.scoreNr / 60;
                    s = "m";
                }
                textHighScore.text += nr.ToString() + ". " + person.Name + ": " + person.scoreNr.ToString("0.00") + s + "\n";
                nr++;
            }
        }
        stream.Close();
    }
}

