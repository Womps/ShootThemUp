using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadSceneOnClick(int sceneIndex)
    {
        /*GameManager gameManager = Object.FindObjectOfType<GameManager>();
        
        // Check if a GameManager has already been assigned to static variable GameManager.Instance or if it's still null.
        if (GameManager.Instance != null)
        {
            // Instantiate gameManager prefab.
            gameManager.CurrentLevel = sceneIndex;
            //gameManager.InitGame();
        }*/

        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}