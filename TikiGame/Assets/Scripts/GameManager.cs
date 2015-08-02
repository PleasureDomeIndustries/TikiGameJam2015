using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    bool playing = false;
    public bool gameInitialized = false;
    List<GameObject> enemies = new List<GameObject>();
	int numToSpawn = 30;
	int numSpawned = 0;

    GameObject currentExit;

    public void AddEnemy(GameObject enemy)
    {
        playing = true;
        enemies.Add(enemy);
        Debug.Log("Enemy Added", gameObject);
    }

    public void RemoveEnemy(GameObject enemy)
    {
		//if (numSpawned++ < numToSpawn) SpawnEnemy(enemy);
//		if (numSpawned++ < numToSpawn) SpawnEnemy(enemy);
		enemies.Remove(enemy);
        Debug.Log("ENEMIES: " + enemies.Count);
    }

	void SpawnEnemy(GameObject enemy) {
		Instantiate (enemy, enemy.transform.position, Quaternion.identity);
	}

    public void OnGUI()
    {
        if (playing && enemies.Count == 0)
        {
            playing = false;
            currentExit.GetComponent<ExitBehavior>().Enable();
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        //boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        if (!gameInitialized)
        {
            gameInitialized = true;
            Application.LoadLevel("Start");
        }
        
    }

    public void StartGame()
    {
        Application.LoadLevel("Level1");
    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void RegisterExit(GameObject exit)
    {
        this.currentExit = exit;
    }
}
  