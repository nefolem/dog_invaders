using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
     private void OnTriggerExit(Collider other)
    {

        if (GameController.gameOver == false && other.tag == "Asteroid")
        {
            GameController.increaseScore(-10);
        }

        Destroy(other.gameObject);
    }
}
