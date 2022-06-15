using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidExplosion;

    [SerializeField]
    private float moveSpeed, rotationSpeed;

    private float size;
    
    void Start()
    {
        size = Random.Range(0.5f, 1.5f);

        Rigidbody asteroid = GetComponent<Rigidbody>();

        asteroid.transform.localScale *= size;

        asteroid.velocity = new Vector3(0, 0, -moveSpeed) / size;
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
   
        if(other.tag == "Lazer")
        {
            GameController.increaseScore(+10);
            Destroy(other.gameObject);
            
        } 
        else if(other.tag == "Player")
        {
            if (GameController.gameOver == true)
            {
                // Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
                // Debug.Log("boom");
                
            }
            GameController.decreaseLives(1);
        } 
        else
        {
            return;
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
