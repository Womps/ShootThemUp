using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;          // GameManager prefab to instantiate.

    public void Awake()
    {
        // Check if a GameManager has already been assigned to static variable GameManager.Instance or if it's still null.
        if (GameManager.Instance == null)
        {
            // Instantiate gameManager prefab.
            Instantiate(this.gameManager);
        }
    }
}