using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }
    private void MoveProjectile()
    {
        transform.position = transform.position + transform.up * projectileSpeed * Time.deltaTime;
    }
}
