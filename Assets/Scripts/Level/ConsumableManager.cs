using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    public PlayerController playerCntl;
    public SimpleHealthBar chargeBar;

    private float respawnTime = 5.0f;
    private float healthBarRespawnTime = 15f;
    private float chargeTime;
    //used for the UI
    private float chargeNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chargeTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //picking up ammo
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "AmmoBox")
            {
                playerCntl.ammo = playerCntl.ammo + 6;
                gameObject.SetActive(false);
                Invoke("Respawn", respawnTime);
            }
            if (gameObject.tag == "SpecialAmmoBox")
            {
                StartCoroutine("ChargeShot");
            }
            if (gameObject.tag == "ShieldAmmoBox")
            {
                playerCntl.iceAmmo = playerCntl.iceAmmo + 2;
                gameObject.SetActive(false);
                Invoke("Respawn", respawnTime);
            }
            if(gameObject.tag == "HealthPack")
            {
                playerCntl.health = playerCntl.health + 2;
                playerCntl.healthBar.UpdateBar(playerCntl.health, 5);
                if(playerCntl.health >= 5)
                {
                    playerCntl.health = 5;
                }
                gameObject.SetActive(false);
                Invoke("Respawn", healthBarRespawnTime);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "SpecialAmmoBox")
            {
                StopCoroutine("ChargeShot");
                chargeNumber = 0;
                playerCntl.chargeBar.UpdateBar(chargeNumber, 2);

            }
        }
    }

    void Respawn()
    {
        gameObject.SetActive(true);
    }

    IEnumerator ChargeShot()
    {
        chargeNumber = chargeNumber + 1;
        playerCntl.chargeBar.UpdateBar(chargeNumber, 2);
        yield return new WaitForSeconds(1.25f);
        chargeNumber = chargeNumber + 1;
        playerCntl.chargeBar.UpdateBar(chargeNumber, 2);
        playerCntl.iceAmmo = playerCntl.iceAmmo + 2;
        yield return new WaitForSeconds(.25f);
        chargeNumber = 0;
        playerCntl.chargeBar.UpdateBar(chargeNumber, 2);
        gameObject.SetActive(false);
        Invoke("Respawn", respawnTime);
    }
}
