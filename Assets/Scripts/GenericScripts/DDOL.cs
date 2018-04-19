using UnityEngine;

public class DDOL : MonoBehaviour
{
    public void Awake()
    {
        // Sets this to not be destroyed when loading another scene.
        DontDestroyOnLoad(this.gameObject);
    }
}