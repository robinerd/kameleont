using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gui.Menu
{
    public class HighScore : MonoBehaviour
    {
        private Boolean hasSubmitted = false;
        public Text playerName1;
        public Text playerName2;

        void Start()
        {
            initHighScore();
        }

        void Update()
        {
            
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

        //private void readHighScoreFile()
        //{

        //    StreamReader stream = File.OpenText("playerprogress" +
        //        "/highscores.txt");
        //    textHighScore.text = "";
        //    int index = 0;
        //    while (!stream.EndOfStream)
        //    {
        //        index = 0;
        //        string line = stream.ReadLine();
        //        //Debug.Log("line: " + line);
        //        if (line == null)
        //            break;

        //        string scoreTxt = "";
        //        string nameTxt = "";
        //        while (index < line.Length && line[index] != ' ')
        //        {
        //            scoreTxt += line[index];
        //            index++;
        //        }
        //        index += 2;
        //        while (index < line.Length)
        //        {
        //            nameTxt += line[index];
        //            index++;
        //        }

        //        try
        //        {
        //            float scoreNr;
        //            float.TryParse(scoreTxt, out scoreNr);

        //            HighScorePerson highScorePerson = new HighScorePerson(nameTxt, scoreNr);
        //            listHighScore.Add(highScorePerson);
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.Log("Exception MenuHighScore: " + e.ToString());
        //        }
        //    }

        //    if (listHighScore.Count > 0)
        //    {
        //        textHighScore.text = "";
        //        listHighScore = listHighScore.OrderBy(o => o.scoreNr).ToList(); //Amaaaziiiing
        //        int nr = 1;
        //        foreach (var person in listHighScore)
        //        {
        //            string s = "s";
        //            if (person.scoreNr > 59)
        //            {
        //                person.scoreNr = person.scoreNr / 60;
        //                s = "m";
        //            }
        //            textHighScore.text += nr.ToString() + ". " + person.Name + ": " + person.scoreNr.ToString("0.00") + s + "\n";
        //            nr++;
        //        }
        //    }
        //    stream.Close();
        //}

        public void ButtonSubmitScore()
        {
            if (!hasSubmitted)
            {
                hasSubmitted = true;
                string scoreString = Score.score.ToString() + "# - " + playerName1.text + " : " + playerName2.text + "\n";
                try
                {
                    File.AppendAllText("playerprogress/highscores.txt", scoreString);
                }
                catch (Exception e)
                {
                    Debug.LogError("Highscore submit crash!: " + e);
                }
            }   
        }
    }
}
