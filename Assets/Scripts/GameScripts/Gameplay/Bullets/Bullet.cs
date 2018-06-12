using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private float damage;
    private Vector2 speed;
    private Vector2 position;
    private BulletType type;

    public BulletType Type
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }

    public Vector2 Speed
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

    public Vector2 Position
    {
        get
        {
            return this.transform.position;
        }

        set
        {
            this.transform.position = value;
        }
    }

    public float Damage
    {
        get
        {
            return this.damage;
        }
        set
        {
            this.damage = value;
        }
    }

    public virtual void Init(float dmg, Vector2 spd, BulletType givenType, Vector2 givenPosition)
    {
        this.Position = givenPosition;

        this.Speed = spd;
        this.Damage = dmg;
        this.Type = givenType;
    }

    public virtual void UpdatePosition()
    {
        this.Position = new Vector2(this.Position.x + (Time.deltaTime * this.Speed.x), this.Position.y + (Time.deltaTime * this.Speed.y));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((this.Type == BulletType.SIMPLE) && (other.tag.Equals("Enemy")))
        {
           this.gameObject.SetActive(false);
           EnemyAvatar enemy = other.GetComponent<EnemyAvatar>();
           enemy.TakeDamage(this.damage);
        }
        else if ((this.type == BulletType.ENEMY) && (other.tag.Equals("Player"))) 
        {
            this.gameObject.SetActive(false);
            PlayerAvatar player = other.GetComponent<PlayerAvatar>();
            player.TakeDamage(this.damage);
        }
        else if (other.tag.Equals("PlayerBullet") || other.tag.Equals("EnemyBullet"))
        {
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }

    public void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}