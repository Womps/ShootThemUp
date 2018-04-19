using UnityEngine;

public enum BulletType
{
    SIMPLE,
    ENEMY
}

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory instance = null;
    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private GameObject enemyBullet;

    public GameObject PlayerBullet
    {
        get;
        set;
    }

    public GameObject EnemyBullet
    {
        get;
        set;
    }

    public Bullet GetBullet(BulletType type)
    {
        GameObject bulletGameObj = null;
        Bullet bullet = null;

        switch (type)
        {
            case BulletType.ENEMY:
                bulletGameObj = Object.Instantiate(this.enemyBullet);
                bullet = bulletGameObj.GetComponent<EnemyBullet>();
                break;
            case BulletType.SIMPLE:
                bulletGameObj = Object.Instantiate(this.playerBullet);
                bullet = bulletGameObj.GetComponent<SimpleBullet>();
                break;
            default:
                break;
        }

        return bullet;
    }

    public static BulletFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new BulletFactory();
        }

        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}