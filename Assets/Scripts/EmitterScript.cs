
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;

    [SerializeField]
    private GameObject firstStageBoss;

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
        float halfSize = transform.localScale.x / 2;
        Vector3 pos = new Vector3(
                Random.Range(-halfSize, halfSize),
                0,
                transform.position.z
                );

        if (Time.time > nextLaunchTime && !GameController.stopEmitter)
        {
            if (Random.Range(1, 18) == 3)
            {
                spawnBonus(pos);
            }
            else
            {
                spawnAsteroid(pos);
            }
        }
        else if (Time.time > nextLaunchTime && GameController.bossFight && !GameController.stageComplete)
        {
            firstStageBoss.SetActive(true);
            spawnBonus(pos);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay) * acceleration;
            acceleration += (step*10);
        }

    }


    private void spawnBonus(Vector3 pos)
    {

        float temp = Random.Range(1, 6);

        switch (temp)
        {
            case 1:
                Instantiate(speedBonus, pos, Quaternion.identity);
                break;
            case 2:
                Instantiate(shieldBonus, pos, Quaternion.identity);
                break;
            case 3:
                Instantiate(tripleFireBonus, pos, Quaternion.identity);
                break;
            case 4:
                Instantiate(fastFireBonus, pos, Quaternion.identity);
                break;
            case 5:
                Instantiate(lifeBonus, pos, Quaternion.identity);
                break;
        }
        
    }


    private void spawnAsteroid(Vector3 pos)
    {

        Instantiate(asteroid, pos, Quaternion.identity);
        nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay) / acceleration;
        acceleration += step;
    }


}
