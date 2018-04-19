using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;             // Store the instance of the GameManager. Used with the Singleton Pattern.
    private BoardManager boardScript;                       // Store a reference to our BoardManager which will set up the scene.
    private int currentLevel = 0;                           // Current level number.

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

        // Get a component reference to the attached BoardManager script.
        this.boardScript = GetComponent<BoardManager>();

        // Call the InitGame function to initialize the first level.
        this.InitGame();
    }

    // Initializes the game for each level.
    public void InitGame()
    {
        // Call the SetupScene function of the BoardManager script.
        this.boardScript.SetupScene(this.currentLevel);
    }

    // Called when exiting the game.
    public void ExitGame()
    {
        // Destroy the GameManager instance.
        Destroy(this.gameObject);
    }
}