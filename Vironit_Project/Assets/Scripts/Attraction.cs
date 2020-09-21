using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public GameObject textE;
    public int GRABI;
    public float grabPower = 10.0f;
    public float throwPower = 10f;   //скорость толчка
    public float RayDistance = 30.0f;   //дистанция

    private bool Grab = false;   //ф-ция притяжения
    private bool Throw = false;   //ф-ция толчка
    private bool InHand = false;
    public Transform offset;
    public Transform hand;
    public Camera camera;
    RaycastHit hit;   //луч


    private void Start()
    {
        GRABI = 0;
    }
    void Update()
    {
        if (InHand == true)
        {
            offset.position = hand.position;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, RayDistance);
            if (hit.rigidbody)
            {
                if (hit.collider.tag == "quit")
                {
                    textE.SetActive(true);
                }
                
                GRABI = GRABI + 1;
                switch (GRABI)
                {
                    case 1:
                        Grab = true;
                        break;
                    case 2:
                        Grab = false;
                        break;
                    default:
                        break;
                }
                if (GRABI == 3)
                {
                    GRABI = 0;
                }
                if (Grab == false)
                {
                    GRABI = 0;
                }
                textE.SetActive(false);


            }
            Debug.Log(GRABI);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Grab)
            {
                GRABI = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {//если нажата лев кн мыши
            if (Grab)
            {
                Grab = false;
                Throw = true;
            }
        }

        if (Grab)
        {//ф-ция притяжения
            if (hit.rigidbody)
            {
                InHand = true;
                hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;

            }
        }

        if (Throw)
        {//ф-ция толчка
            if (hit.rigidbody)
            {
                InHand = false;
                hit.rigidbody.velocity = camera.ScreenPointToRay(Input.mousePosition).direction * throwPower;
                Throw = false;
            }
        }
    }

    private void Grabb()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, RayDistance);
        if (hit.rigidbody)
        {
            Grab = true;
        }
    }
}
