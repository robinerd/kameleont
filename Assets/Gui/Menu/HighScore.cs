using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Gui.Menu
{
    public class HighScore : MonoBehaviour
    {
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

        public void ButtonSubmitScore()
        {
            string scoreString = Score.score.ToString() + "# - " + playerName1.text + " : " + playerName2.text + "\n";
            try
            {
                if (playerName1.text.Length > 0 && playerName2.text.Length > 0)
                {
                    //Only players with friends are allowed to score
                    File.AppendAllText("playerprogress/highscores.txt", scoreString);
                }
                SceneManager.LoadScene("MainMenu");
            }
            catch (Exception e)
            {
                Debug.LogError("Highscore submit crash!: " + e);
            }
        }
    }
}
