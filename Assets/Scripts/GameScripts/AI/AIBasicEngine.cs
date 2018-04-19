using UnityEngine;

public class AIBasicEngine : MonoBehaviour
{
    private BaseAvatar baseAvatar;

    // Use this for initialization
    void Start()
    {
        this.baseAvatar = this.GetComponent<BaseAvatar>();
    }

    // Update is called once per frame
    void Update ()
    {
        this.transform.position = new Vector2(this.transform.position.x - (Time.deltaTime * this.baseAvatar.Speed), this.transform.position.y);
	}
}