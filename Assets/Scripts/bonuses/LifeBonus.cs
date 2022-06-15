using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bound" || other.tag == "Asteroid" || other.tag == "Bonus")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            ShipScript.lifeBonus = true;
            Destroy(gameObject);
        }
        
    }
}
