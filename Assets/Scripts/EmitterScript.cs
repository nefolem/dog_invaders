
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;

    [SerializeField]
    private GameObject speedBonus, shieldBonus, tripleFireBonus, fastFireBonus, lifeBonus;

    [SerializeField]
    private float minDelay, maxDelay;

    [SerializeField]
    private float step = 0.005f;

    private float nextLaunchTime;
    private float acceleration = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextLaunchTime)
        {
            float halfSize = transform.localScale.x / 2;
            Vector3 pos = new Vector3(
                Random.Range(-halfSize, halfSize), 
                0, 
                transform.position.z
                );

            if (Random.Range(1, 4) == 3)
            {
                //float temp = Random.Range(1, 5);
                Instantiate(speedBonus, pos, Quaternion.identity);
                // switch (temp)
                // {
                //     case 1: 
                //         Instantiate(speedBonus, pos, Quaternion.identity);
                //         break;
                //     case 2:
                //         Instantiate(shieldBonus, pos, Quaternion.identity);
                //         break;
                //     case 3:
                //         Instantiate(tripleFireBonus, pos, Quaternion.identity);
                //         break;
                //     case 4:
                //         Instantiate(fastFireBonus, pos, Quaternion.identity);
                //         break;
                //     case 5:
                //         Instantiate(lifeBonus, pos, Quaternion.identity);
                //         break;
                // }
                
            }
            else
            {
                Instantiate(asteroid, pos, Quaternion.identity);
                nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay) / acceleration;
                acceleration += step;
            }
        }
    }
}
