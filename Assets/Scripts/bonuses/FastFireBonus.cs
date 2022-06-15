using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFireBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bound" || other.tag == "Asteroid" || other.tag == "Bonus")
        {
            return;
        }
        else if (other.tag == "Player")
        {           
            ShipScript.fastFireBonus = true;            
            Destroy(gameObject);
        }        
    }
}
