using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce = 10;
    private float gravityModifier = 2.0f;
    public bool gameOver = false;
    bool isOnFloor = true;
    private PlayerAnimation animation;
    public ParticleSystem particle, particleTwo;
    public AudioClip jumpSound, crashSound;
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animation = GameObject.Find("Player").GetComponent<PlayerAnimation>();
        audioSource =GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    void Update()
    {
        Jump();
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor && gameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnFloor = false;
            animation.animator.SetFloat("Speed_f", 0.6f);
            animation.animator.SetTrigger("Jump_trig");
            particleTwo.Stop();
            audioSource.PlayOneShot(jumpSound, 1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = true;
            particleTwo.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            particle.Play();
            particleTwo.Stop();
            audioSource.PlayOneShot(crashSound, 1);
        }
    }
}
