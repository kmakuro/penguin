using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float shootCooldown = 0.5f;
    private bool canShoot = true;
    public Transform firePoint;
    public GameObject bulletPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            
                Shoot();
           
            canShoot = false;
            Invoke(nameof(ResetShoot), shootCooldown);
        }
    }
    private void ResetShoot()
    {
        canShoot = true;
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}

