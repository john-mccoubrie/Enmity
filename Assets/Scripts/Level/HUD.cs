using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerController playerCntl;
    public Text ammoText;
    public Text specialAmmoText;

    void Start()
    {
    }

    void Update()
    {
        AmmoUI();
        
    }
    void AmmoUI()
    {
        ammoText.text = "Ammo: "+ playerCntl.ammo.ToString();
        specialAmmoText.text = "Special: " + playerCntl.iceAmmo.ToString();
    }
}
