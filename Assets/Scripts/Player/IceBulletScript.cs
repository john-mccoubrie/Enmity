using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    Vector3 shootDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        
    }
    void FixedUpdate()
    {
        //shoots bullet in the direction of the mouse
        rb.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
    
}
