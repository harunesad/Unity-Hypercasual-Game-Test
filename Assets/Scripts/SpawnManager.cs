using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController controller;
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
    void Update()
    {

    }
    public void SpawnObstacle()
    {
        if (controller.gameOver == false)
        {
            Instantiate(prefab, spawnPosition, prefab.transform.rotation);
        }
    }
}
