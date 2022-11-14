using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoScript : MonoBehaviour
{
    public float health;
    public Transform player;
    float time;

    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;

    public bool shieldUp;
    public Transform shieldParent;
    private float shieldValue;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar shieldBar;

    //boss movement
    public float speed;
    public float nextCharge;
    private float startTime = 0.0f;
    private float chargeTime = 3.0f;

    //states
    bool waiting;
    bool charging;
    bool collision;
    bool miss;
    bool slowed;
   
    // Start is called before the first frame update
    void Start()
    {
        waiting = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        BossTarget();
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        Waiting();
        Charge();
        Death();
    }

    //when the bos is done waiting it will charge at a set speed
    void Charge()
    {
        if (charging)
        {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            
            if (miss)
            {
                startTime = 0;
                waiting = true;
                charging = false;
            }
        }
    }

    //Once the boss has charged and targetted the player it will wait until the next charge time
    void Waiting()
    {
        if (waiting)
        {
            BossTarget();
            if (startTime >= nextCharge)
            {
                miss = false;
                charging = true;
                waiting = false;
            }
        }
    }


    void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel("VictoryMenu");
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (shieldUp == false)
            {
                health = health - 1;
                healthBar.UpdateBar(health, 5);
                speed = speed + 5;
                shieldUp = true;
                shieldValue = 1;
                shieldBar.UpdateBar(shieldValue, 1);
                foreach (Transform child in shieldParent)
                {
                    child.gameObject.SetActive(true);
                    //GameObject.FindGameObjectWithTag("Shield").SetActive(true);
                }
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "IceBullet")
        {
            shieldUp = false;
            shieldValue = 0;
            shieldBar.UpdateBar(shieldValue, 1);
            foreach (Transform child in shieldParent)
            {
                child.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.tag == "Wall")
        {
            miss = true;
        }
    }
    //method for targetting and facing the player after a charge
    void BossTarget()
    {
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
