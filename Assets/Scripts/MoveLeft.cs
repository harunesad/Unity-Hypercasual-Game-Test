using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private PlayerController playerController;
    private PlayerAnimation playerAnimation;
    private float posX = -7;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnimation = GameObject.Find("Player").GetComponent<PlayerAnimation>();
    }
    void Update()
    {
        Left();
    }
    public void Left()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            playerAnimation.animator.SetFloat("Speed_f", 0.6f);
        }
        if (gameObject.transform.position.x < posX && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (playerController.gameOver == true)
        {
            playerAnimation.animator.SetInteger("DeathType_int", 1);
            playerAnimation.animator.SetBool("Death_b", true);
        }
    }
}
