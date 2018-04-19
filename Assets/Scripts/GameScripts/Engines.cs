using UnityEngine;
using System.Collections;

public class Engines : MonoBehaviour
{
    private Vector2 pos;
   // private Vector2 position;
    private BaseAvatar baseAvatar;
    private Transform myTransform;

    [SerializeField]
    private float maxPosX;
    [SerializeField]
    private float minPosX;
    [SerializeField]
    private float maxPosY;
    [SerializeField]
    private float minPosY;

    public Vector2 Pos
    {
        get
        {
            return this.pos;
        }
        set
        {
            this.pos = value;
        }
    }

    /*public Vector2 Position
    {
        get
        {
            return this.transform.position;
        }

        set
        {
            this.transform.position = value;
        }
    }*/

	// Use this for initialization
	void Start ()
    {
        baseAvatar = this.GetComponent<BaseAvatar>();
        myTransform = this.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = new Vector3 (this.Pos.x, this.Pos.y, 0.0f) * Time.deltaTime * baseAvatar.Speed;

        this.myTransform.Translate(newPos);

        this.myTransform.position = new Vector3(Mathf.Clamp(this.myTransform.position.x, minPosX, maxPosX), Mathf.Clamp(this.myTransform.position.y, minPosY, maxPosY), this.myTransform.position.z);
	}
}
