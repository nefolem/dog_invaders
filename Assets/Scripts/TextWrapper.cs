using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWrapper : MonoBehaviour
{

    public TMP_Text textObject;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        textObject.color = color;

    }

    // Update is called once per frame
    void Update()
    {
        textObject.color = color;

    }
}
