using UnityEngine;

public class LoseInputController : MonoBehaviour
{
    private bool esc;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.esc = Input.GetButtonDown("Cancel");

        if (this.esc)
        {
            GameManager.Instance.ExitGame();
        }
    }
}