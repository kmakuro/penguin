using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene1 : MonoBehaviour
{
    public int health;
    public int Maxhealth = 3;


    public HealthbarBehaviour Healthbar;
    void Start()
    {
        health = Maxhealth;
        Healthbar.SetHealth(health, Maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("bullet"))
        {
            
            
            health--;
            Healthbar.SetHealth(health, Maxhealth);
            Destroy(col.gameObject);

            if (health <= 0)
            {
                killself();
            }
        }
    }
    private void killself()
    {
        Destroy(gameObject);
    }*/

}
