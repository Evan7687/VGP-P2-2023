using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float zRange = 10.0f;
    public bool gameOver = false;
    public GameObject pauseScreen;
    public bool paused;
    public GameObject titleScreen;
    public bool isGameActive;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

         if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    void ChangePaused()
    {
        if(!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        titleScreen.gameObject.SetActive(false);
    }
}
