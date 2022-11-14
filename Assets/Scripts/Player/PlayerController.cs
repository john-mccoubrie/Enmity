using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //movement
    private Rigidbody2D rb2d;
    public float speed;

    //shooting
    public float ammo;
    public float iceAmmo;
    public GameObject shot;
    public GameObject iceShot;
    public Transform shotSpawn;


    //player life
    public float health;
    float deathTime;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar chargeBar;

    //animator
    public Animator animator;
    public GameObject explosion;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Shoot();
        Movement();
        Death();
    }

    void Movement()
    {
        //movement controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(moveHorizontal, moveVertical) * speed;
        //run animation
        if (moveHorizontal != 0) {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

    }
    void Shoot()
    {
        //The player with shoot with a left click and if they have ammo
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            ammo = ammo - 1;
        }
        if (Input.GetMouseButtonDown(1) && iceAmmo > 0)
        {
            Instantiate(iceShot, shotSpawn.position, shotSpawn.rotation);
            iceAmmo = iceAmmo - 1;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //player take damage
        if (other.gameObject.tag == "EnemyBullet")
        {
            health = health - 1;
            healthBar.UpdateBar(health, 5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossBullet")
        {
            health = health - 1;
            healthBar.UpdateBar(health, 5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Boss2")
        {
            health = health - 2;
            healthBar.UpdateBar(health, 5);
        }
        if (other.gameObject.tag == "Shield")
        {
            health = health - 2;
            healthBar.UpdateBar(health, 5);
        }

    }
    //player die
    void Death()
    {
            if (health <= 0)
            {
                GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

                for (int i = 0; i < GameObjects.Length; i++)
                {
                    Destroy(GameObjects[i]);
                }
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


