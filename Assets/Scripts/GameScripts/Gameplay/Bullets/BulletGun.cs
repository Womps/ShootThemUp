using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletGun : MonoBehaviour
{
    [SerializeField]
    private float maxEnergy;
    private float energy;
    [SerializeField]
    private float damage;
    [SerializeField]
    private Vector2 speed;
    private float coolDown;
    private BulletFactory bulletF;
    private List<Bullet> bullets;
    [SerializeField]
    private float cost;
    [SerializeField]
    private float regen;
    private float timer;

    public float Regen
    {
        get
        {
            return this.regen;
        }
        set
        {
            this.regen = value;
        }
    }

    public float Cost
    {
        get
        {
            return this.cost;
        }
        set
        {
            this.cost = value;
        }
    }

    public float MaxEnergy
    {
        get
        {
            return this.maxEnergy;
        }
        set
        {
            this.maxEnergy = value;
        }
    }

    public float Energy
    {
        get
        {
            return this.energy;
        }
        set
        {
            this.energy = value;
        }
    }

    public List<Bullet> Bullets
    {
        get;
        set;
    }

    public BulletFactory BulletF
    {
        get;
        set;
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

    public float CoolDown
    {
        get
        {
            return this.coolDown;
        }
        set
        {
            this.coolDown = value;
        }
    }

    public float Timer
    {
        get
        {
            return this.timer;
        }
        set
        {
            this.timer = value;
        }
    }

    public void Fire()
    {
        if(this.CoolDown < Time.time)
        {
            if (this.energy >= this.cost)
            { 
                Bullet newBulletObj = null;

                if (this.bullets.Exists(b => !b.gameObject.activeSelf))
                {
                    newBulletObj = this.bullets.Find(b => !b.gameObject.activeSelf);
                    newBulletObj.gameObject.SetActive(true);
                }
                else
                {
                    newBulletObj = this.BulletF.GetBullet(BulletType.SIMPLE);
                }
                this.bullets.Add(newBulletObj);
                newBulletObj.Init(this.damage, this.speed, BulletType.SIMPLE, this.transform.position);
                this.CoolDown = Time.time + 0.1f;
                this.energy -= this.cost;
            }
        }
    }

	// Use this for initialization
	void Start ()
    {
        this.CoolDown = 0.0f;
        this.BulletF = BulletFactory.GetInstance();
        this.bullets = new List<Bullet>();
        this.energy = maxEnergy;
        this.timer = Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.timer += Time.deltaTime;

        if (this.timer >= 0.1f)
        {
            if ((this.energy + this.regen) <= this.maxEnergy)
                this.energy += this.regen;
            else
            {
                this.energy += (this.maxEnergy - this.energy);
            }
            this.timer = Time.deltaTime;
        }
    }
}
