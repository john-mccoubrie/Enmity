using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float activateDist;
    private float freezeTime;
    public GameObject doorTrigger;
    public GameObject explosion;

    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < activateDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Bullet")
            {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "IceBullet")
            {
                speed = 5;
                Destroy(other.gameObject);
            }
        }
    }
