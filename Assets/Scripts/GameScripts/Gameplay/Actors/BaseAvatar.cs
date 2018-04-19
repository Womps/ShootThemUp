using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxHealth;
    private float health;
    private bool tookDamages = false;

    public float Speed
    {
        get
        {
            return this.speed;
        }

        set
        {
            this.speed = value;
        }
    }

    public float MaxHealth
    {
        get
        {
            return this.maxHealth;
        }
        set
        {
            this.maxHealth = value;
        }
    }

    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }

    public bool TookDamages
    {
        get
        {
            return this.tookDamages;
        }
        set
        {
            this.tookDamages = value;
        }
    }

    public void TakeDamage(float dmg)
    {
        this.tookDamages = true;
        this.health = this.health - dmg;
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }
}