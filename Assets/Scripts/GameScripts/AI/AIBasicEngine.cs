using UnityEngine;

public class AIBasicEngine : MonoBehaviour
{
    private BaseAvatar baseAvatar;      // Reference to the avatar script of the AI.

    // Use this for initialization.
    public void Start()
    {
        // Getting a reference to the AI avatar script. This will be used to update the position of the AI considering the speed.
        this.baseAvatar = this.GetComponent<BaseAvatar>();
    }

    // Update is called once per frame.
    public void Update ()
    {
        // Updating the position of the AI avatar.
        this.transform.position = new Vector2(this.transform.position.x - (Time.deltaTime * this.baseAvatar.Speed), this.transform.position.y);
    }
}