using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour
{
    //so we can access the GameManager Script and it's public variable and methods
    private GameManager gameManager;
    private Camera cam;
    //Remember Vector3 gives us an x, y and z
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;
    //remember that bool is short for boolean (true/false variable)
    private bool swiping = false;

    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        //This "finds the GameManager script so we can use public variables and methods from it
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Target>())
        {
            //Destroy the target
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
