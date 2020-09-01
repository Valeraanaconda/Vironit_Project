using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGameObject : MonoBehaviour
{
    public GameObject monitor;
    public GameObject textE;
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
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
            textE.SetActive(true);

            //Debug.DrawRay(ray.origin, ray.direction*10, Color.yellow);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (monitor.activeSelf) monitor.SetActive(false);
                else monitor.SetActive(true);
            }
        }
        else
        {
            textE.SetActive(false);
        }
    }
}
