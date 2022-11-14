using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    Collider2D[] playerInRadius;
    public LayerMask obstacleMask, playerMask;
    public List<Transform> visiblePlayer = new List<Transform>();

    public float speed;
    public Transform player;

    public EnemyShoot shoot;

    void FixedUpdate()
    {
        FindVisiblePlayer();
    }
    void FindVisiblePlayer()
     {
        visiblePlayer.Clear();

        Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2)
            {
                float distancePlayer = Vector2.Distance(transform.position, player.position);
                if(!Physics2D.Raycast(transform.position, dirPlayer, distancePlayer, obstacleMask))
                {
                    visiblePlayer.Add(player);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                shoot.Shoot();
                }
            }
        
     }
    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if(!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Cos(angleDeg * Mathf.Deg2Rad));
    }
}
