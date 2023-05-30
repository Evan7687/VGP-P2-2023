using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject titleScreen;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartMyGame);
        gameManager = GameObject.Find("PlayerController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMyGame()
    {
        gameManager.StartGame();
    }
}
