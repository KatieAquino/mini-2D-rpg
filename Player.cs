using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;

    private Vector2 facingDirection;

    [Header("Sprites")]
    public Sprite downSprite;
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    // Components
    private Rigidbody2D rig;
    private SpriteRenderer sr;

    void Awake()
    {
        // Get the components.
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Get the horizontal & vertical keyboard inputs.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 vel = new Vector2(x, y);

        UpdateSpriteDirection();

        if (vel.magnitude != 0)
            facingDirection = vel;
        
        rig.velocity = vel * moveSpeed;
    }

    void UpdateSpriteDirection()
    {
        if(facingDirection == Vector2.up)
            sr.sprite = upSprite;
        else if(facingDirection == Vector2.down)
            sr.sprite = downSprite;
        else if(facingDirection == Vector2.left)
            sr.sprite = leftSprite;
        else if(facingDirection == Vector2.right)
            sr.sprite = rightSprite;
    }
}
