using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameController.gameOver == true)
            {
                // Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
                // Debug.Log("boom");
                
            }
            GameController.decreaseLives(1);
            Destroy(gameObject);
        } 
        else
        {
            
            return;
        }

        Destroy(gameObject);
        
    }
}
