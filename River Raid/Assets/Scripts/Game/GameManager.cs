using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager: MonoBehaviour{

    static int score = 0;
    public Text textScore;
    public static int reserveJets = 3;          //jatos reservas (vidas)
    public static int dificulty = 1;

    [SerializeField]
    GameObject  currentMap;
    GameObject topMap,bottomMap;

    public GameObject[] brightMaps, darkMaps;
    int mapIndex;

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

    void Start()
    {
        SetUpMaps();
    }

    void SetUpMaps()
    {
        instance.bottomMap = null;

        instance.mapIndex = 0;

        int r = Random.Range(0, instance.brightMaps.Length);
        instance.topMap = ((instance.mapIndex % 2) == 0) ? instance.darkMaps[r] : instance.brightMaps[r];
        if ((instance.mapIndex % 2) == 0)
            instance.topMap = Instantiate(instance.darkMaps[r]);
        else
            instance.topMap = Instantiate(instance.brightMaps[r]);

        instance.topMap.transform.position = new Vector3(instance.topMap.transform.position.x, instance.currentMap.transform.position.y + 128 * 8, instance.topMap.transform.position.z);
    }

    public static void GenerateMap()
    {
        Destroy(instance.bottomMap);             //fazer object pooling futuramente
        instance.bottomMap = instance.currentMap;
        instance.currentMap = instance.topMap;

        instance.mapIndex++;

        int r = Random.Range(0, instance.brightMaps.Length);
        instance.topMap = ((instance.mapIndex % 2) == 0) ? instance.darkMaps[r]: instance.brightMaps[r];
        if((instance.mapIndex % 2) == 0)
            instance.topMap = Instantiate(instance.darkMaps[r]);
        else
            instance.topMap = Instantiate(instance.brightMaps[r]);

        instance.topMap.transform.position = new Vector3(instance.topMap.transform.position.x, instance.currentMap.transform.position.y + 128 * 8, instance.topMap.transform.position.z);
    }

    public static void Reset()
    {

    }

    public static void GameOver()
    {

    }

}
