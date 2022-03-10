using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rigid;
    private GameObject player;
    private float pos = 12;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rigid.AddForce(lookDirection * speed);
        if (transform.position.z < -pos || transform.position.z > pos ||
            transform.position.x <-pos || transform.position.x > pos)
        {
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor"))
    //    {
    //        Destroy(gameObject);
    //    } 
    //}
}
