﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class HighScorePerson
{
    public string Name;
    public int scoreNr;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="scoreNr">How long time it took until the player reached the score amount required to reach the highscore.</param>
    public HighScorePerson(string name, int scoreNr)
    {
        this.Name = name;
        this.scoreNr = scoreNr;
    }

    public HighScorePerson()
    {

    }
}
