using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1;
    public Text skor;
    public int point;
    public Text gameOver;
    public bool gameActive = false;
    public Button restart;
    public GameObject titleScreen;
    void Start()
    {
        StartCoroutine(SpawnTarget());
        skor.text = "Point: " + point;
        gameActive = false;
    }
    void Update()
    {
        if (point < 0)
        {
            gameOver.text = "Game Over";
            gameActive= false;
            restart.gameObject.SetActive(true);
        }
    }
    IEnumerator SpawnTarget()
    {
        while (gameActive == true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void PointAdd(int add)
    {
        point += add;
        skor.text = "Point: " + point;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        gameActive = true;
        titleScreen.SetActive(false);
        point = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        PointAdd(0);
    }
}
