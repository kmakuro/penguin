using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public Vector3 respawnPoint;
    public bool die = false;
    public int health = 3;
    [SerializeField] private Text Healthtext;
    void Start()
    {
        respawnPoint = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) 
        {
            health -= 3;
            Healthtext.text = " X  " + health;
        }
        if  (collision.gameObject.CompareTag("Ebullet")) 
        {
            health --;
            Healthtext.text = " X  " + health;
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            health -= 1;
            Healthtext.text = " X  " + health;
        }
        if ( health <= 0)
        {
            die = true;
            Healthtext.text = " X  " + health;
        }
        if (collision.gameObject.CompareTag("underground"))
        {
            Debug.Log("Collision");
            die = true;
            Healthtext.text = " X  " + health;
        }
    }

    void Update()
    {
        if (die == true)
        {
            transform.position = respawnPoint;
            die = false;
            health = 3;
            Healthtext.text = " X  " + health;
        }
       
    }

    

}
