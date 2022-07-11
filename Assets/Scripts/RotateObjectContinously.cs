using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectContinously : MonoBehaviour
{
    public float rotationsPerMinute = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }
}
