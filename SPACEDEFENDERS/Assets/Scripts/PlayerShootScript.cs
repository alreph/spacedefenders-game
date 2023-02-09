using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject playerShip;
    public PlayerMoveScript moveScript;
    [HideInInspector] public bool isAttacking;

    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        moveScript = playerShip.GetComponent<PlayerMoveScript>();
    }

    void Update()
    {
        ShootLogic();
    }

    void ShootLogic()
    {
        if(Input.GetMouseButton(0));
        {
            isAttacking = true;
            //moveScript.FaceMouse();
            Debug.Log($"Player shooting.");
        }

        if(Input.GetMouseButtonUp(0));
        {
            isAttacking = false;
            Debug.Log($"Shooting stopped.");
        }
    }
}