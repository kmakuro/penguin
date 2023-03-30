using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public SpriteRenderer Passdoor;
    public Collider2D colliderToTurnOff;
    
    private int coin = 0;
    [SerializeField] private Text cointext;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            coin++;
            cointext.text = " : " + coin;
        }
    }
    private void Update()
    {

        if (coin >= 10)
        {
            this.colliderToTurnOff.enabled = false;
            this.Passdoor.enabled = false;
        }
        
    }

}
