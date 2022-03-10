using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 10, maxSpeed = 13;
    private float Torque = 10;
    private float spawnPosX = 4;
    private float spawnPosY = 1;
    private float destroyPosY = -1;
    private GameManager gameManager;
    public ParticleSystem particleSystem;
    public int pointValue;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }
    void Update()
    {
        if (transform.position.y < destroyPosY)
        {
            Destroy(gameObject);
        }
        Limit();
    }
    private void OnMouseDown()
    {
        if (gameManager.gameActive == true)
        {
            Destroy(gameObject);
            gameManager.PointAdd(pointValue);
            Instantiate(particleSystem, transform.position, particleSystem.transform.rotation);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-Torque, Torque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, 0);
    }
    public void Limit()
    {
        if (transform.position.x < -spawnPosX)
        {
             transform.position = new Vector3(-spawnPosX, transform.position.y, 0);
        }
        else if (transform.position.x > spawnPosX)
        {
            transform.position = new Vector3(spawnPosX, transform.position.y, 0);
        }
        else if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else if (transform.position.z > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
