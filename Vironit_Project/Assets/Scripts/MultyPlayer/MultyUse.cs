using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyUse : MonoBehaviour
{
    public bool takekey = false;


    public PhotonView playerView;

    private GameObjectsPool gameObjectsPool;

    private Canvas screen;
    private Canvas button;

    private SafeController safe;
    private Camera playerCamera;

    private GameObject window;
    private GameObject textE;
    private GameObject safeNumber;
    private GameObject monitor;
    private GameObject laptop;
    private GameObject player;
    private GameObject password;
    private GameObject key;

    public MouseLook mouse;
    public MultyMovement movement;
    private CatMove catMove;
    private OpenDoor door;

    private Vector3 startLaptopPosition;
    private Quaternion startLaptopRotation;

    private float zOffset = -0.4f;
    private float xAnglePosition = 25f;
    private float laptopX;
    private float laptopY;

    private void Start()
    {
        gameObjectsPool = GameObject.FindGameObjectWithTag("GameObjectPool").GetComponent<GameObjectsPool>();

        player = gameObjectsPool.playerPrefab.transform.GetChild(0).gameObject;

        textE = gameObjectsPool.textE;
        password = gameObjectsPool.password;
        key = gameObjectsPool.key;
        monitor = gameObjectsPool.monitor;
        safeNumber = gameObjectsPool.safeNumber;
        laptop = gameObjectsPool.laptop;
        startLaptopPosition = laptop.transform.position;
        startLaptopRotation = laptop.transform.rotation;

        safe = gameObjectsPool.axis.GetComponent<SafeController>();
        catMove = gameObjectsPool.cat.GetComponent<CatMove>();
        door = gameObjectsPool.door.GetComponent<OpenDoor>();
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

            if (hit.collider.name == "laptop")
            {
                laptop.GetComponent<PhotonView>().TransferOwnership(playerView.Owner);
                laptopX = ray.origin.x;
                laptopY = ray.origin.y - 0.1f;
                screen = laptop.transform.GetChild(2).GetComponent<Canvas>();
                button = laptop.transform.GetChild(3).GetComponent<Canvas>();
                screen.worldCamera = playerCamera;
                button.worldCamera = playerCamera;
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
                door.GetComponent<PhotonView>().TransferOwnership(playerView.Owner);
                textE.SetActive(true);
                UseDoor();
            }
            else if (hit.collider.tag == "Safe")
            {
                safe.GetComponent<PhotonView>().TransferOwnership(playerView.Owner);
                textE.SetActive(true);
                UseSafe();
            }
            else if (hit.collider.tag == "key")
            {
                key.GetComponent<PhotonView>().TransferOwnership(playerView.Owner);
                textE.SetActive(true);
                use_key();
            }
            else if (hit.collider.tag == "Window")
            {
                window = hit.transform.gameObject;
                window.GetComponent<PhotonView>().TransferOwnership(playerView.Owner);
                textE.SetActive(true);
                BreakWindow();
            }
        }
        else
        {
            textE.SetActive(false);
            safeNumber.SetActive(false);
            password.SetActive(false);
            safe.usable_safe = false;
        }
    }
    public void use_key()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            takekey = true;
            key.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.E) && takekey == true)
        {
            gameObjectsPool.doorIsOpen.PlayOneShot(gameObjectsPool.openDoor);
            door.openDoor();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObjectsPool.doorIsOpen.PlayOneShot(gameObjectsPool.closeDoor);
        }

    }
    public void UseCat()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            password.SetActive(true);
            if (takekey == true) password.SetActive(false);
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            mouse.mouseSensitivity = 0.0f;
            movement.speed = 0.0f;
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            laptop.transform.position = startLaptopPosition;
            laptop.transform.rotation = startLaptopRotation;
            Cursor.visible = false;
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
    public void BreakWindow()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(gameObjectsPool.sphere, window.transform.position, Quaternion.identity);
            gameObjectsPool.sounds.gameObject.SetActive(true);
        }
    }
}