using UnityEngine;
using UnityEngine.UI;
using System;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Sprite[] HeartSprites;

    [SerializeField]
    private Sprite[] LightningSprites;

    [SerializeField]
    private Image HeartUI;

    [SerializeField]
    private Image EnergyUI;

    private PlayerAvatar player;
    private BulletGun gun;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAvatar>();
        gun = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletGun>();
    }

    public void Update()
    {
        int curHealth = Convert.ToInt32(player.Health);
        int curEnergy = Convert.ToInt32(Math.Round(gun.Energy));

        HeartUI.sprite = HeartSprites[curHealth];
        EnergyUI.sprite = LightningSprites[curEnergy];
    }
}
