using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject speedEffect;

    [SerializeField]
    private float speedMultiplier;
    
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bound" || other.tag == "Asteroid")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            //Instantiate(speedEffect, other.transform.position, Quaternion.identity);
            //ShipScript.increaseSpeed(speedMultiplier);
            //Debug.Log("start increase");
            ShipScript.speedBonus = true;
            
            Destroy(gameObject);



        }
        
        //Destroy(gameObject);

    }
}
