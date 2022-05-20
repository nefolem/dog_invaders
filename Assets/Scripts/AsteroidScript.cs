using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidExplosion, playerExplosion;

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
   
        if(other.tag == "Bound" || other.tag == "Asteroid" || other.tag == "Bonus")
        {
            return;
        } 
        else if(other.tag == "Player")
        {
            if (GameController.gameOver == true)
            {
                Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            GameController.decreaseLives(-1);
        } 
        else
        {
            GameController.increaseScore(+10);
            Destroy(other.gameObject);
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
