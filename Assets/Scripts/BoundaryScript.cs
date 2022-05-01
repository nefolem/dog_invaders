using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
     private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Asteroid")
        {
            GameController.increaseScore(-10);
        }

        Destroy(other.gameObject);
    }
}
