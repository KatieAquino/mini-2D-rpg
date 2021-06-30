using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;

    [Header("Target")]
    public float chaseRange;
    public float attackRange;
    private Player player;

    // Components
    private Rigidbody2D rig;

    void Awake()
    {
        // Get the player targer.
        player = FindObjectOfType<Player>();

        // Get the rigidbody component
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float playerDist = Vector3.Distance(transform.position, player.transform.position);

        if(playerDist <= attackRange)
        {
            // Attack the player.
            rig.velocity = Vector2.zero;
        }
        else if(playerDist <= chaseRange)
        {
            Chase();
        }
        else{
            rig.velocity = Vector2.zero;
        }
    }

    void Chase()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        
        rig.velocity = dir * moveSpeed;
    }
}
