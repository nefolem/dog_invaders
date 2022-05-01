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

    // Start is called before the first frame update
    void Start()
    {
        speed = constSpeed;
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if(pause)
        {
            return;
        }*/

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
    }

    public static void increaseSpeed(float speedMultiplier)
    {
        speed = speed * speedMultiplier;

        //float timer = 0;
        //timer += Time.deltaTime;
        //if(timer > 3)
        //{
        //    Debug.Log("3 sec proshlo");
        //    speed = constSpeed;
        //}
    }

    public static void decreaseSpeed()
    {
        Debug.Log("3 sec proshlo");
        speed = constSpeed;
    }

    //public static void castShield()
    //{
    //    bool shield = true;
    //}
}
