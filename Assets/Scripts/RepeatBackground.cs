using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeat;
    void Start()
    {
        startPos = transform.position;
        repeat = GetComponent<BoxCollider>().size.x/2;
    }
    void Update()
    {
        if (transform.position.x < startPos.x - repeat)
        {
            transform.position = startPos;
        }
    }
}
