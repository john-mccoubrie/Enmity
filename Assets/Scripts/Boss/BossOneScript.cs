using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossOneScript : MonoBehaviour
{
    public float health;
    public bool shieldUp;
    public float spawnDelay;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    public float characterVelocity;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    public SimpleHealthBar healthBar;
    public SimpleHealthBar shieldBar;
    private float shieldValue;
    public Transform shieldParent;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        if (Time.time > spawnDelay)
        {
            shieldUp = true;
            latestDirectionChangeTime = 0f;
            calcuateNewMovementVector();
        }
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnDelay)
        {
            Death();
            //if the changeTime was reached, calculate a new movement vector
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time;
                calcuateNewMovementVector();
            }


            //move enemy: 
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            calcuateNewMovementVector();
        }
        if (other.gameObject.tag == "Bullet")
        {
            if (shieldUp == false) { 
            health = health - 1;
            healthBar.UpdateBar(health, 5);
            shieldUp = true;
            shieldValue = 1;
            shieldBar.UpdateBar(shieldValue, 1);
             foreach(Transform child in shieldParent)
                {
                    child.gameObject.SetActive(true);
                    //GameObject.FindGameObjectWithTag("Shield").SetActive(true);
                }
            
                //create more ice ammo box
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "IceBullet")
        {
            //Destroy(GameObject.FindGameObjectWithTag("Shield"));
            //GameObject.FindGameObjectWithTag("Shield").SetActive(false);
            shieldUp = false;
            shieldValue = 0;
            shieldBar.UpdateBar(shieldValue, 1);
            foreach (Transform child in shieldParent)
            {
                child.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
            //Debug.Log(shieldUp);
        }
    }
    void Death()
    {
        if(health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            SceneManager.LoadScene("Level2Menu");
        }
    }
}
