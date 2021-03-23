using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBehavior : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected Vector2 direction;

    [SerializeField] protected bool onGround;
    [SerializeField] protected float gravity, fallMultiplier;

    [SerializeField] protected Animator anim;
    [SerializeField] protected float groundLenght;
    [SerializeField] protected LayerMask groundLayer;

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Move(float _direction)
    {
        if (_direction != 0)
        {
            anim.SetBool("walk", true);
        }
        direction.x = _direction;
        transform.Translate(direction * speed * Time.deltaTime);
        ChangeFlip();
    }

    public void ChangeFlip()
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
        onGround = false;
        anim.SetBool("jump", true);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void ModifyPhysic()
    {
        if (onGround)
        {
            rb.gravityScale = 0;
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0)
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }

    public bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundLenght, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * groundLenght, Color.red);
        if (hit)
        {
            return true;
        }
        else
        {
            anim.SetBool("jump", false);
            return false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            anim.SetBool("jump", false);
        }
    }

    

}
