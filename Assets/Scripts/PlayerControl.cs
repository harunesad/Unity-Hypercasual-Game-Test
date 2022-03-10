using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private float playerSpeed = 3;
    public GameObject focus;
    private bool hasPowerup = false;
    private float powerupStrength = 5.0f;
    public GameObject powerupIndicator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(focus.transform.forward * playerSpeed * vertical);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject, 0.1f);
            StartCoroutine(Powerup());
        }
    }
    IEnumerator Powerup()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup == true)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("collision" + collision.gameObject.name + "powerup" + hasPowerup);
        }
    }
}
