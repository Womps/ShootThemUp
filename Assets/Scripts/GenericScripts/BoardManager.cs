using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;                                // Player avatar prefab.
    [SerializeField]
    private GameObject enemyPrefab;                                 // Enemy avatar prefab.
    [SerializeField]
    private GameObject background;                                  // Background prefab.
    [SerializeField]
    private GameObject hud;                                         // HUD prefab.
    [SerializeField]
    private float enemyIntervalSpawn;                               // The interval before 2 enemies to spawn.
    private float timer;                                            // A timer used to count the interval before two enemy spawn.
    private List<BaseAvatar> enemies = new List<BaseAvatar>();      // A list used to store and recycle enemies avatar. This allow to avoid prefab reinstanciation for each enemy to spawn.
    private Transform boardHolder;                                  // A variable to store a reference to the transform of our Board object.

    // Clears our list of enemies and prepares it to generate a new board.
    private void InitialiseList()
    {
        // Clear our list of enemies.
        this.enemies.Clear();
    }

    // Sets up the background of the game board.
    private void BoardSetup()
    {
        // Instantiate Board and set boardHolder to its transform.
        this.boardHolder = new GameObject("Board").transform;

        // Instantiate the GameObject instance of the background, using the prefab given.
        GameObject backGroundInstance = Instantiate(this.background, this.background.transform.position, Quaternion.identity);

        // Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
        backGroundInstance.transform.SetParent(this.boardHolder);
    }

    // Sets up the player.
    private void PlayerSetup()
    {
        // Instantiate the player prefab given.
        Instantiate(this.playerPrefab, this.transform);
    }

    // Sets up the hud
    private void HudSetup()
    {
        // Instantiate the hud prefab given.
        GameObject hudInstance = Instantiate(this.hud, this.hud.transform.position, Quaternion.identity);

        // Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
        hudInstance.transform.SetParent(this.boardHolder);
    }

    // SetupScene initializes our level and calls the previous functions to lay out the game board.
    public void SetupScene(int scene)
    {
        // Creates the background.
        this.BoardSetup();

        // If we are in the game scene
        if(scene > 0)
        {
            // Then, create setup the player.
            this.PlayerSetup();

            // And, create the Hud.
            this.HudSetup();
        }

        // Reset our list of enemies.
        this.InitialiseList();
    }

    // Use this for initialization.
    public void Start ()
    {
        this.timer = Time.deltaTime;
    }

    // Update is called once per frame.
    public void Update ()
    {
        this.timer += Time.deltaTime;

        if (this.timer >= this.enemyIntervalSpawn)
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

            this.timer = Time.deltaTime;
        }
    }
}