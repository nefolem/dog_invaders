using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField]
    private GameObject lazerShot, lazerGun;

    [SerializeField]
    private float shotDelay;
    private float nextShotTime = 0;

    [SerializeField] private static float constSpeed = 30;
    private static float speed;
    [SerializeField] private float xMin, xMax, zMin, zMax;
    [SerializeField] private float tilt;

    Rigidbody ship;

    [HideInInspector] public static bool speedBonus, shieldBonus, tripleFireBonus, fastFireBonus, lifeBonus = false;
    static float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = constSpeed;
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

        if(Time.time > nextShotTime && Input.GetKey(KeyCode.Space))
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        //Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);

        if(speedBonus)
            increaseSpeed(60);

    }


    public static void increaseSpeed(float speedMultiplier)
    {
        Debug.Log("start");
        speed = speedMultiplier;


        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer > 3.0f)
        {
            Debug.Log("3 sec proshlo");
            speed = constSpeed;
            timer = 0;
            speedBonus = false;
        }
    }

    public static void decreaseSpeed()
    {
        Debug.Log("3 sec proshlo");
        speed = constSpeed;
    }

    public static void castShield()
    {
        bool shield = true;
    }
}
