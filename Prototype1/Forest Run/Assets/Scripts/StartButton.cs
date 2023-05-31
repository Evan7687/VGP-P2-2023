using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject titleScreen;
    private Button start;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<Button>();
        start.onClick.AddListener(StartMyGame);
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMyGame()
    {
        playerController.StartGame();
    }
}
