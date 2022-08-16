using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private string ENEMY = "Enemy";
    private string PLAYER = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(ENEMY) || collision.CompareTag(PLAYER))
        
            Destroy(collision.gameObject);
        
    }

}
