using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public Animator animator;
    public GameObject player;
    int length;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetBool("Hit", true);
        }

        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) & Input.GetKey(KeyCode.D))
            {
                direction = 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) & Input.GetKey(KeyCode.A))
            {
                direction = 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) & Input.GetKey(KeyCode.W))
            {
                direction = 3;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) & Input.GetKey(KeyCode.S))
            {
                direction = 4;
            }
        }
        else
        {
            if(dashTime < 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                player.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                dashTime -= Time.deltaTime;
            }
            if(direction == 1)
            {
                rb.AddForce(Vector3.right * dashSpeed);
                player.transform.localScale = new Vector3(1, 0.5f, 1);
            }
            if (direction == 2)
            {
                rb.AddForce(Vector3.left * dashSpeed);
                player.transform.localScale = new Vector3(1, 0.5f, 1);
            }
            if (direction == 3)
            {
                rb.AddForce(Vector3.up * dashSpeed);
                player.transform.localScale = new Vector3(1, 0.5f, 1);
            }
            if (direction == 4)
            {
                rb.AddForce(Vector3.down * dashSpeed);
                player.transform.localScale = new Vector3(1, 0.5f, 1);
            }
        }
    }
  
}
