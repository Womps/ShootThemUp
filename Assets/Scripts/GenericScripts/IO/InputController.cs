using UnityEngine;

public class InputController : MonoBehaviour
{
    private Engines engine;
    private BulletGun gun;
    private bool esc;

    // Use this for initialization
    void Start ()
    {
        this.engine = this.GetComponent<Engines>();
        this.gun = this.GetComponent<BulletGun>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        this.esc = Input.GetButtonDown("Cancel");

        this.engine.Pos = new Vector2(x, y);
        

        if (this.esc)
        {
            //GameManager.Instance.ExitGame();
        }

        if (Input.GetKey("space"))
        {
			this.gun.Fire();
		}
    }
}