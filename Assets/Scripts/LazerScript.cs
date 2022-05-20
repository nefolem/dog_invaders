using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [HideInInspector]
    public static bool tripleFire, right, left = false;

    // Start is called before the first frame update
    void Start()
    {
        if(tripleFire == false)
        {
            transform.FindChild("triple").gameObject.SetActive(false);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            GetComponent<Rigidbody>().rotation = Quaternion.identity;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            GetComponent<Rigidbody>().rotation = Quaternion.identity;
            transform.FindChild("triple").gameObject.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
