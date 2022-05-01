using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject speedEffect;

    [SerializeField]
    private float speedMultiplier;

    float timer = 0;

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
            StartCoroutine(SpeedTimer());
            //Destroy(gameObject);



        }
        
        //Destroy(gameObject);

    }

    IEnumerator SpeedTimer()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(3);
        Debug.Log("end");
        //ShipScript.decreaseSpeed();
        
    }
}
