﻿using UnityEngine;
using System.Collections.Generic;

public class AIBasicBulletGun : MonoBehaviour
{
    [SerializeField]
    private float bulletDamage;             // How much damages the bullets shot by the AI will do.
    [SerializeField]
    private Vector2 bulletSpeed;            // The speed of the bullets shot by the AI.
    private float coolDown;                 // Cooldown between two shots by the AI.
    private BulletFactory bulletFactory;    // Reference to the Bullet Factory.
    private List<Bullet> bullets;           // List

    public void Fire()
    {
        if (this.coolDown < Time.time)
        {
            Bullet newBulletObj = null;

            if (this.bullets.Exists(b => !b.gameObject.activeSelf))
            {
                newBulletObj = this.bullets.Find(b => !b.gameObject.activeSelf);
                newBulletObj.gameObject.SetActive(true);
            }
            else
            {
                newBulletObj = this.bulletFactory.GetBullet(BulletType.ENEMY);
                this.bullets.Add(newBulletObj);
            }
            newBulletObj.Init(this.bulletDamage, this.bulletSpeed, BulletType.ENEMY, this.transform.position);
            this.coolDown = Time.time + 1.5f;
        }
    }

    // Use this for initialization
    void Start()
    {
        this.coolDown = 0.0f;
        this.bulletFactory = BulletFactory.GetInstance();
        this.bullets = new List<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Fire();
    }
}
