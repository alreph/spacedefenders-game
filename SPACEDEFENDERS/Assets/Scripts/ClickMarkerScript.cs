using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMarkerScript : MonoBehaviour
{  
    public GameObject clickMarker;
    private Camera cam;
    [SerializeField] private float destroyTimer = 100f;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float destroyStep = destroyTimer * Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 spawnPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject spawnedObject = Instantiate(clickMarker, spawnPosition, Quaternion.identity);
            Destroy(spawnedObject, destroyStep);
        }
    }
}