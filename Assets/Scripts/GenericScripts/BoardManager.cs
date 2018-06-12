using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject background;                                  // Background prefab.
    [SerializeField]
    private GameObject hud;                                         // HUD prefab.
    private Transform boardHolder;                                  // A variable to store a reference to the transform of our Board object.

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
        if(scene > 0 && scene < 2)
        {
            // And, create the Hud.
            this.HudSetup();
        }
    }

    // Use this for initialization.
    public void Start ()
    {

    }

    // Update is called once per frame.
    public void Update ()
    {

    }
}