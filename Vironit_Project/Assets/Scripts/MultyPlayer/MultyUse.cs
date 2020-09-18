using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyUse : MonoBehaviour
{
    private Canvas screen;
    private Canvas button;

    private MouseLook mouse;
    private PlayerMovement movement;
    private CatMove catMove;
    private OpenDoor door;
    //private SafeController safe;
    private Camera playerCamera;

    private GameObject textE;
    //private GameObject safeNumber;
    private GameObject monitor;
    private GameObject laptop;
    private GameObject player;

    Vector3 startLaptopPosition = new Vector3(-5.4f, 2.1f, 6.15f);
    Vector3 startLaptopRotation = new Vector3(0f, 180f, 0f);
    Quaternion startLaptopRotationAngles;

    private float zOffset = -0.4f;
    private float xAnglePosition = 25f;
    private float laptopX;
    private float laptopY;

    private void Start()
    {
        startLaptopRotationAngles.eulerAngles = startLaptopRotation;
        player = GameObject.FindGameObjectWithTag("Player");
        textE = GameObject.FindGameObjectWithTag("TextE");
        //safeNumber = GameObject.FindGameObjectWithTag("Safe");
        movement = player.GetComponent<PlayerMovement>();
        door = GetComponent<OpenDoor>();
        //safe = GetComponent<SafeController>();
        mouse = GetComponent<MouseLook>();
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

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.0f, layerMask))
        {
            // Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

            if (hit.collider.name == "laptop")
            {
                laptopX = ray.origin.x;
                laptopY = ray.origin.y - 0.1f;
                laptop = hit.transform.gameObject;
                screen = laptop.transform.GetChild(2).GetComponent<Canvas>();
                button= laptop.transform.GetChild(3).GetComponent<Canvas>();
                screen.worldCamera = playerCamera;
                button.worldCamera = playerCamera;
                textE.SetActive(true);
                UseLaptop();
            }
            else if (hit.collider.name == "TVset")
            {
                textE.SetActive(true);
                Transform tv = hit.transform;
                monitor = tv.GetChild(0).gameObject;
                UseTV();
            }
            else if (hit.collider.tag == "Cat")
            {
                catMove = hit.transform.gameObject.GetComponent<CatMove>();
                textE.SetActive(true);
                UseCat();
            }
            else if (hit.collider.tag == "Door")
            {
                UseDoor();
            }
            else if (hit.collider.tag == "Safe")
            {
                textE.SetActive(true);
                UseSafe();
            }
        }
        else
        {
            textE.SetActive(false);
            //safeNumber.SetActive(false);
            //safe.usable_safe = false;
        }
    }

    public void UseSafe()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            textE.SetActive(false);
            //safeNumber.SetActive(true);
            //safe.usable_safe = true;
        }
        //if (safe.usable_safe == false)
        //{
        //    textE.SetActive(true);
        //}
    }
    public void UseDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.openDoor();
        }
    }
    public void UseCat()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            catMove.sayMeay();
        }
    }
    public void UseLaptop()
    {
        Vector3 laptopPosition = new Vector3(laptopX, laptopY, transform.position.z - zOffset);

        Quaternion laptopRotation = Quaternion.Euler(xAnglePosition, player.transform.rotation.eulerAngles.y - 180, 0);

        if (Input.GetKeyDown(KeyCode.E) && (laptop.transform.position == startLaptopPosition))
        {
            laptop.transform.position = laptopPosition;
            laptop.transform.rotation = laptopRotation;
            Cursor.lockState = CursorLockMode.Confined;
            mouse.mouseSensitivity = 0.0f;
            movement.speed = 0.0f;
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            laptop.transform.position = startLaptopPosition;
            laptop.transform.rotation = startLaptopRotationAngles;
            Cursor.lockState = CursorLockMode.Locked;
            mouse.mouseSensitivity = 100.0f;
            movement.speed = 2.0f;
        }
    }
    public void UseTV()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (monitor.activeSelf) monitor.SetActive(false);
            else monitor.SetActive(true);
        }
    }
}
