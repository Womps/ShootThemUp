using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAvatar : BaseAvatar
{
    [SerializeField]
    private string loseScreen;

    // Use this for initialization
    void Start ()
    {
        this.Health = this.MaxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((this.Health <= 0.0f) && this.TookDamages)
        {
            this.Die();
            SceneManager.LoadScene(loseScreen);
        }
    }
}