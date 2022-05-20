using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovementScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bonus = GetComponent<Rigidbody>();

        bonus.velocity = new Vector3(0, 0, -moveSpeed);
    }


}
