
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]private float speed = 2.5f;
    [SerializeField]private float rotationSpeed = 10f;
    private Vector3 mouseClick;
    private Vector3 mousePosition;
    private Camera cam;
    [HideInInspector] public bool isMoving = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        // store the position of the mouse
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        MoveLogic();
        if(!isMoving) FaceMouse();
    }
    
    void Init()
    {
        mouseClick = transform.position;
        if (!cam) cam = Camera.main;
    }
    
    // make object face the mouse cursor
    void FaceMouse()
    {
        //create a vector from object to mouse position and make the object face that way
        Vector2 objectToMouse = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = objectToMouse;
    }

    void MoveLogic()
    {
        // if right mouse is pressed, store current mouse position as a variable and set isMoving to true
        if (Input.GetMouseButtonDown(1))
        {
            mouseClick = mousePosition;
            {
                isMoving = true;
            }
        }

        float step = speed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;
        
       
        Vector3 mouseDirection = mouseClick - transform.position;
        
        // move towards the clicked location and toggle movement flag to false upon arrival
        if(isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, mouseClick, step);

            Quaternion rotateTo = Quaternion.LookRotation(mouseDirection, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, rotationStep);

            if (Vector2.Distance(transform.position, mouseClick) < 0.1f)
            {
                isMoving = false;
                Debug.Log($"Player moving to: {transform.position}.");
            }
        }
        
        // if "S" is pressed, sets movement flag to false, halting movement
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            isMoving = false;
            Debug.Log($"Player stopped.");
        }
    }
}


    