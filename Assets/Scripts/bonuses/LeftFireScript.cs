using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFireScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-20, 0, speed);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90, -20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
