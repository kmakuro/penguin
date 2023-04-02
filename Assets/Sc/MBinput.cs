using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameDev3.Project;

public class MBinput : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveleft;
    private bool moveright;
    private float horizontalMove;
    public float speed;
    public float JumpForce = 1.0f;
    private bool canJump = true;

    private bool canShoot = true;
    private bool isfire;
    public float shootCooldown = 1f;
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;


    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveleft = false;
        moveright = false;
    }

    public void PointerDownLeft()
    {
        moveleft = true;
        
    }
    public void PointerUpLeft()
    {
        moveleft = false;
    }
    public void PointerDownRight()
    {
        moveright = true;
        
    }
    public void PointerUpRight()
    {
        moveright = false;

    }
    public void PointerJump()
    {
        
        if (canJump)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
      
    }
    public void Fire()
    {
        if (canShoot)
        {
            isfire = true;
            FindObjectOfType<AudioManager>().Play("Shoot");
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

            canShoot = false;
            Invoke(nameof(ResetShoot), shootCooldown);
        }
       
    }

    void Update()
    {
        MovePlayer();

        if (rb.velocity.y == 0 && horizontalMove != 0)
        {
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("IsFalling", false);
        }
        if (rb.velocity.y > 0)
        {
            anim.SetBool("IsJump", true);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("IsFalling", true);
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            canJump = true;
        }
        if (Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            canJump = false;
        }


        //fire
        if (isfire)
        {
            anim.SetBool("Isfire", true);
        }
        if (!isfire)
        {
            anim.SetBool("Isfire", false);
        }
        if (!canShoot)
        {
            isfire = false;
        }



    }


    private void MovePlayer()
    {
        if (moveleft)
        {
            
            horizontalMove = -speed;
            transform.rotation = horizontalMove < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
        
        else if (moveright)
            {
            
            horizontalMove = speed;
            transform.rotation = horizontalMove < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
         else
            {
            horizontalMove = 0;
            }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
    private void ResetShoot()
    {

        canShoot = true;

    }

}

    
