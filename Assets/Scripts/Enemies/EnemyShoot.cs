using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject shot;
    public Transform enemyShotSpawn;
    public float fireRate;
    float nextFire;
    float nextFireExplosive;
    public float spawnDelay;

    public GameObject explosiveShot;
    public Transform explosiveSpawn;
    public float explosiveRate;
    float fuseTime;

    public void Start()
    {
        
    }

    public void FixedUpdate()
    {
        if (Time.time > spawnDelay) {
            Shoot();
            ShootExplosive();
        }
    }
    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, enemyShotSpawn.position, enemyShotSpawn.rotation);
        }
    }
    public void ShootExplosive()
    {
        if (Time.time > nextFireExplosive)
        {
            nextFireExplosive = Time.time + explosiveRate;
            Instantiate(explosiveShot, explosiveSpawn.position, explosiveSpawn.rotation);
        }
    }
}
