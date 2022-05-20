using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField]
    private GameObject lazerShot, lazerGun;

    [SerializeField]
    private float constShotDelay;
    private float shotDelay;
    private float nextShotTime = 0;

    [SerializeField] private float constSpeed = 30;
    private float speed;
    [SerializeField] private float xMin, xMax, zMin, zMax;
    [SerializeField] private float tilt;

    Rigidbody ship;

    [HideInInspector] public static bool speedBonus, shieldBonus, tripleFireBonus, fastFireBonus, lifeBonus = false;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = constSpeed;
        shotDelay = constShotDelay;
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; // x y z
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);
        
        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ);

        if(tripleFireBonus)
            castTripleFire();

        if(speedBonus)
            increaseSpeed(60);

        if(shieldBonus)
            castShield();

        if(fastFireBonus)
            decreaseShotDelay();

        if(lifeBonus)
            addHeart();
            
        if(Time.time > nextShotTime)
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);        
            nextShotTime = Time.time + shotDelay;
        }

    }


    public void increaseSpeed(float speedMultiplier)
    {
        speed = speedMultiplier;
        timer += Time.deltaTime;
        if(timer > 5)
        {
            speed = constSpeed;
            timer = 0;
            speedBonus = false;
        }
    }


    public void castShield()
    {
        GameController.shield = true;
        timer += Time.deltaTime;
        if(timer > 5)
        {
            timer = 0;
            GameController.shield = false;
            shieldBonus = false;
        }
    }

    public void castTripleFire()
    {
        LazerScript.tripleFire = true;
        timer += Time.deltaTime;
        if(timer > 6)
        {
            timer = 0;         
            LazerScript.tripleFire = false;
            tripleFireBonus = false;
        }

    }

    public void decreaseShotDelay()
    {
        shotDelay = 0.2f;
        timer += Time.deltaTime;
        if(timer > 5)
        {
            Debug.Log("fast fire ends");
            timer = 0;
            shotDelay = constShotDelay;
            fastFireBonus = false;
        }
    }

    public void addHeart()
    {
        GameController.increaseLives();
        lifeBonus = false;
    }

   
}
