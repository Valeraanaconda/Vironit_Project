﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyUse : MonoBehaviourPun, IPunObservable
{
    private GameObjectsPool gameObjectsPool;

    private Canvas screen;
    private Canvas button;

    private AudioListener audioListener;

    private MouseLook mouse;
    private MultyMovement movement;
    //private SafeController safe;
    private Camera playerCamera;

    private GameObject textE;
    //private GameObject safeNumber;
    private GameObject monitor;
    private GameObject laptop;
    private GameObject player;
    private CatMove catMove;
    private OpenDoor door;

    private Vector3 startLaptopPosition;
    private Quaternion startLaptopRotation;

    private bool isActivemonitor;

    private float zOffset = -0.4f;
    private float xAnglePosition = 25f;
    private float laptopX;
    private float laptopY;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Debug.Log("STREAM");
            stream.SendNext(isActivemonitor);
        }
        else if (stream.IsReading)
        {
            Debug.Log("RECIEVE");
            isActivemonitor = (bool)stream.ReceiveNext();
        }
    }

    private void Start()
    {
        gameObjectsPool = GameObject.FindGameObjectWithTag("GameObjectPool").GetComponent<GameObjectsPool>();

        player = gameObjectsPool.playerPrefab.transform.GetChild(0).gameObject;
        textE = gameObjectsPool.textE;
        monitor = gameObjectsPool.monitor;
        laptop = gameObjectsPool.laptop;
        startLaptopPosition = laptop.transform.position;
        startLaptopRotation = laptop.transform.rotation;

        //safeNumber = GameObject.FindGameObjectWithTag("Safe");
        movement = player.GetComponent<MultyMovement>();
        catMove = gameObjectsPool.cat.GetComponent<CatMove>();
        door = gameObjectsPool.door.GetComponent<OpenDoor>();
        //safe = GetComponent<SafeController>();
        mouse = GetComponent<MouseLook>();
        playerCamera = GetComponent<Camera>();
        audioListener = GetComponent<AudioListener>();

        if (!photonView.IsMine)
        {
            Debug.LogWarning("ВЫБОР СДЕЛАН");
            playerCamera.gameObject.SetActive(false);
            audioListener.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (photonView.IsMine) 
        {
            GetObject();

            //if (isActivemonitor) monitor.SetActive(false);
            //else monitor.SetActive(true);
        }
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
                textE.SetActive(true);
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
            if (monitor.activeSelf) isActivemonitor = true;
            else isActivemonitor = false;
        }
    }
}