using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;                                // Player avatar prefab.
    [SerializeField]
    private GameObject enemyPrefab;                                 // Enemy avatar prefab.
    [SerializeField]
    private float enemyIntervalSpawn;                               // The interval before 2 enemies to spawn.
    private static GameManager instance = null;                     // Store the instance of the GameManager. Used with the Singleton Pattern.
    private BoardManager boardScript;                               // Store a reference to our BoardManager which will set up the scene.
    private int currentLevel = 0;                                   // Current level number.
    private List<BaseAvatar> enemies = new List<BaseAvatar>();      // A list used to store and recycle enemies avatar. This allow to avoid prefab reinstanciation for each enemy to spawn.
    private float timer;                                            // A timer used to count the interval before two enemy spawn.
    private bool doingSetup = true;                                 // Boolean to check if we're setting up the game.

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    public int CurrentLevel
    {
        get;
        set;
    }

    // Awake is always called before any Start functions.
    public void Awake()
    {
        // Check if instance already exists.
        if (instance == null)
        {
            // If not, set instance to this.
            instance = this;
        }
        // If instance already exists and it's not this :
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(this.gameObject);
        }
    }

    public void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += this.OnLevelFinishedLoading;
    }

    public void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to !
        SceneManager.sceneLoaded -= this.OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // Add one to our level number.
        this.currentLevel = scene.buildIndex;

        // Call InitGame to initialize our level.
        this.InitGame();
    }

    // Sets up the player.
    private void PlayerSetup()
    {
        // Instantiate the player prefab given.
        Instantiate(this.playerPrefab, this.transform);
    }

    // Initializes the game for each level.
    public void InitGame()
    {
        // While doingSetup is true, enemies are not accessed.
        this.doingSetup = true;

        // Get a component reference to the attached BoardManager script.
        this.boardScript = GetComponent<BoardManager>();

        // Clears our list of enemies to prepare for the next level.
        this.enemies.Clear();

        // Call the SetupScene function of the BoardManager script.
        this.boardScript.SetupScene(this.currentLevel);

        if (this.currentLevel > 0)
        {
            // Then, setup the player.
            this.PlayerSetup();
        }

        // Set doingSetup to false allowing the script to access enemies again.
        this.doingSetup = false;

        // Initialising the timer used to count the time before spawning a new enemy.
        this.timer = Time.deltaTime;
    }

    public void Update()
    {
        this.timer += Time.deltaTime;

        if (this.timer >= this.enemyIntervalSpawn && !this.doingSetup)
        {
            this.SpawnEnemy();

            this.timer = Time.deltaTime;
        }
    }

    public void SpawnEnemy()
    {
        GameObject newEnemyGameObj = null;
        BaseAvatar newEnemy = null;

        if (this.enemies.Exists(b => !b.gameObject.activeSelf))
        {
            newEnemy = this.enemies.Find(b => !b.gameObject.activeSelf);
            newEnemy.gameObject.SetActive(true);
            newEnemy.Spawn(new Vector3(this.enemyPrefab.transform.position.x, Random.Range(-66.0f, 66.0f), 0), this.transform.rotation);
        }
        else
        {
            newEnemyGameObj = Instantiate(this.enemyPrefab, new Vector3(this.enemyPrefab.transform.position.x, Random.Range(-66.0f, 66.0f), 0), this.transform.rotation);
            newEnemy = newEnemyGameObj.GetComponent<BaseAvatar>();
            this.enemies.Add(newEnemy);
        }
    }

    // Called when exiting the game.
    public void ExitGame()
    {
        // Destroy the GameManager instance.
        Destroy(this.gameObject);
    }
}