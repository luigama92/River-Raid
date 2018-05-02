using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager: MonoBehaviour{

    static int score = 0;
    public Text textScore;
    public static int reserveJets = 3;          //jatos reservas (vidas)
    public static int dificulty = 1;            // em 1 o jogador contralaos misseis, em 0 os misseis seguem seu curso normal

    [SerializeField]
    Transform mapsParent;

    [SerializeField]
    GameObject  currentMap;   //referencia ao mapa q o jogador estah
    GameObject topMap,bottomMap;  // referencia aos mapas da frente e de tras

    int mapSize;

    public GameObject[] brightMaps, darkMaps; // vetor com mapas prontos. os com grama clara e os com grama escura
    int mapIndex; //numero do mapa atual

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
        mapSize = 128 * 8; //128 eh o numero de tiles no mapa na vertical e 8 eh o tamanho do tile em pixels
        instance = this;
        score = 0;
    }

    void Start()
    {
        SetUpMaps();
    }

    void SetUpMaps()
    {
        instance.bottomMap = null;

        instance.mapIndex = 0;

        //numero para randomizar mapa q sera criado a frente
        int r = Random.Range(0, instance.brightMaps.Length); // o vetor de mapas claros tem o mesmo tamanho do vetor de mapas escuros 

        instance.topMap = ((instance.mapIndex % 2) == 0) ? instance.darkMaps[r] : instance.brightMaps[r];
        if ((instance.mapIndex % 2) == 0)
            instance.topMap = Instantiate(instance.darkMaps[r],mapsParent);
        else
            instance.topMap = Instantiate(instance.brightMaps[r], mapsParent);

        //128 eh o tamanho
        instance.topMap.transform.position = new Vector3(instance.topMap.transform.position.x, instance.currentMap.transform.position.y + mapSize, instance.topMap.transform.position.z);
    }

    public static void GenerateMap()
    {
        //destroi mapa de tras e cria um novo a frente aleatoriamente

        Destroy(instance.bottomMap);             //fazer object pooling futuramente
        instance.bottomMap = instance.currentMap;
        instance.currentMap = instance.topMap;

        instance.mapIndex++;

        int r = Random.Range(0, instance.brightMaps.Length);
        instance.topMap = ((instance.mapIndex % 2) == 0) ? instance.darkMaps[r]: instance.brightMaps[r];
        if((instance.mapIndex % 2) == 0)
            instance.topMap = Instantiate(instance.darkMaps[r], instance.mapsParent);
        else
            instance.topMap = Instantiate(instance.brightMaps[r], instance.mapsParent);

        instance.topMap.transform.position = new Vector3(instance.topMap.transform.position.x, instance.currentMap.transform.position.y + 128 * 8, instance.topMap.transform.position.z);
    }

    public static void Reset() //chamado depois da animacao de morte. a falta de tempo nao deixou fazer o sistema de vidas e checkpoints :(
    {
        SceneManager.LoadScene(0);
    }
    

}
