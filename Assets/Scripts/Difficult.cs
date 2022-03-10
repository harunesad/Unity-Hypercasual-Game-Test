using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficult : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int diffuculty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    public void Click()
    {
        gameManager.StartGame(diffuculty);
    }
}
