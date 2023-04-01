using UnityEngine.SceneManagement;
using UnityEngine;
using GameDev3.Project;

public class player : MonoBehaviour
{ public float MovementSpeed = 1.0f;
    public  float JumpForce = 1.0f;
    
    private Rigidbody2D _rigidbody;
    //shoot/
    private bool canShoot = true;
    private bool isfire;
    public float shootCooldown = 0.5f;
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;

    public Animator anim;
    private float dtrX;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        

        

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            Jump();
        }

        //animation 

        if(_rigidbody.velocity.y == 0 && movement !=0)
        {
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
        
        //jump
        if (_rigidbody.velocity.y == 0)
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("IsFalling", false);
        }
        if (_rigidbody.velocity.y > 0)
        {
            anim.SetBool("IsJump", true);
        }
        if (_rigidbody.velocity.y < 0)
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("IsFalling", true);
        }

        // shooting

        if (canShoot && Input.GetButtonDown("Fire1"))
        {

            isfire = true;
            FindObjectOfType<AudioManager>().Play("Shoot");
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

            canShoot = false;
            Invoke(nameof(ResetShoot), shootCooldown);

        }
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
    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("Jump");
    }
    private void ResetShoot()
    {
        
        canShoot = true;
        
    }
   
}
