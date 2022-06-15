using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleFireBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bound" || other.tag == "Asteroid" || other.tag == "Bonus")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            ShipScript.tripleFireBonus = true;            
            Destroy(gameObject);
        }        
    }
}
