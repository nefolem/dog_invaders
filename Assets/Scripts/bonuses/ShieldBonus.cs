using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject shieldEffect;

    // [SerializeField]
    // private float speedMultiplier;
    
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bound" || other.tag == "Asteroid" || other.tag == "Bonus")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            //Instantiate(speedEffect, other.transform.position, Quaternion.identity);
            //ShipScript.increaseSpeed(speedMultiplier);
            //Debug.Log("start increase");
            ShipScript.shieldBonus = true;
            
            Destroy(gameObject);

        }
        
    }
}
