using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float xSize = Camera.main.orthographicSize*3;
        transform.localScale = new Vector3(xSize, 11, Camera.main.aspect * xSize);
    }
}
