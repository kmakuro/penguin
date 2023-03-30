using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Ebullet;
    float timebetween;
    public int health ;
    public int maxhealth = 3;
    public float starttimebetween;

    public HealthbarBehaviour Healthbar;
    void Start()
    {
        health = maxhealth;
        Healthbar.SetHealth(health, maxhealth);
        timebetween = starttimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if(timebetween <= 0)
        {
            Instantiate(Ebullet, firepoint.position,firepoint.rotation);
            timebetween = starttimebetween;
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("bullet"))
        {
            Destroy(col.gameObject);
            health--;
            Healthbar.SetHealth(health, maxhealth);
            if (health <= 0)
            {
                killself();
            }
        }
    }
    private void killself()
    {
        Destroy(gameObject);
    }

}
