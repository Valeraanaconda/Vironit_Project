using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGameObject : MonoBehaviour
{
    private MouseLook mouse;
    public PlayerMovement movement;

    public GameObject textE;
    public GameObject safeNumber;

    public GameObject monitor;
    public GameObject laptop;
    public GameObject player;
    public CatMove catMove;
    public OpenDoor door;
    public SafeController safe;
        
    private Camera playerCamera;

    Vector3 startLaptopPosition;
    Quaternion startLaptopRotation;

    Vector3 laptopPosition;
    Quaternion laptopRotation;

    private float yOffset = -0.15f;
    private float zOffset = -0.35f;
    private float xAnglePosition = 25f;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        mouse = GetComponent<MouseLook>();

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

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.0f, layerMask))
        {
            // Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

            if (hit.collider.name == "laptop")
            {
                textE.SetActive(true);
                UseLaptop();
            }
            else if (hit.collider.name == "TVset")
            {
                textE.SetActive(true);
                UseTV();
            }
            else if (hit.collider.tag == "Cat")
            {
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
            safeNumber.SetActive(false);
            safe.usable_safe = false;
        }
    }

    public void UseSafe()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            textE.SetActive(false);
            safeNumber.SetActive(true);
            safe.usable_safe = true;
        }
        if (safe.usable_safe == false)
        {
            textE.SetActive(true);
        }


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
        laptopPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z - zOffset);

        laptopRotation = Quaternion.Euler(xAnglePosition, player.transform.rotation.eulerAngles.y - 180, 0);

        if (Input.GetKeyDown(KeyCode.E) && (laptop.transform.position == startLaptopPosition))
        {
            laptop.transform.position = laptopPosition;
            laptop.transform.rotation = laptopRotation;
            // Костыль помогающий свести к минимуму погрешности
            //laptop.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            Cursor.lockState = CursorLockMode.Confined;
            mouse.mouseSensitivity = 0.0f;
            movement.speed = 0.0f;
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            laptop.transform.position = startLaptopPosition;
            laptop.transform.rotation = startLaptopRotation;
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
