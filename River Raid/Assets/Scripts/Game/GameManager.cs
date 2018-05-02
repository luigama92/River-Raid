using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager: MonoBehaviour{

    static int score = 0;
    public Text textScore;
    public static int reserveJets = 3;          //jatos reservas (vidas)
    public static int dificulty = 1;

    public static GameManager instance;

    public static int Score {
        set
        {
            score = value;
            if (score < 999999)
                instance.textScore.text = score.ToString();
            else
            {
                instance.textScore.text = "999999";

            }
        }

        get { return score; }
    }

    void Awake()
    {
        instance = this;
    }

    public static void Reset()
    {

    }

    public static void GameOver()
    {

    }

}
