using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour{

    static int score = 0;
    public static int reserveJets = 3;          //jatos reservas (vidas)
    public static int dificulty = 1;

    public static int Score {
        set
        {
            score = value;
        }

        get { return score; }
    }

    public static void Reset()
    {

    }

    public static void Die()
    {

    }

    public static void GameOver()
    {

    }

}
