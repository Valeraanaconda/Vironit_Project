using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGameObject : MonoBehaviour
{
    public GameObject monitor;
    public GameObject textE;
    public GameObject laptop;

    private Camera playerCamera;

    Vector3 startLaptopPosition;
    Quaternion startLaptopRotation;

    Vector3 laptopPosition;
    Quaternion laptopRotation;

    private float yOffset = 0.53f;
    private float zOffset = 0.57f;
    private float xAnglePosition = 16f;
    private float yAnglePosition = 180f;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();

        startLaptopPosition = laptop.transform.position;
        startLaptopRotation = laptop.transform.rotation;
    }
    void Update()
    {
        GetObject();
    }

    public void GetObject() 
    {
        int layerMask = 00001000;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2, 0));

        if (Physics.Raycast(ray, 1.5f, layerMask))
        {
            laptopPosition = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z + zOffset);

            laptopRotation = Quaternion.Euler(xAnglePosition, yAnglePosition, 0);

            textE.SetActive(true);

            //Debug.DrawRay(ray.origin, ray.direction*10, Color.yellow);

            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    if (monitor.activeSelf) monitor.SetActive(false);
            //    else monitor.SetActive(true);
            //}

            if (Input.GetKeyDown(KeyCode.E) && (laptop.transform.position == startLaptopPosition))
            {
                laptop.transform.position = laptopPosition;
                laptop.transform.rotation = laptopRotation;
            }

            else if (Input.GetKeyDown(KeyCode.E) && (laptop.transform.position == laptopPosition))
            {
                laptop.transform.position = startLaptopPosition;
                laptop.transform.rotation = startLaptopRotation;
            }

        }
        else
        {
            textE.SetActive(false);
        }
    }
}
