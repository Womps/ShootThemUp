public class EnemyAvatar : BaseAvatar
{
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
        }
    }

    protected void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}