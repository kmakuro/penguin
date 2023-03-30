using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 4.5f;
    public float lifetime = 1f;
    public int damage = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // rb.velocity = transform.right * Speed;
        Destroy(gameObject, lifetime);
    }

   
    void Update()
    {
       MoveProjectile();
    }
    private void MoveProjectile()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
