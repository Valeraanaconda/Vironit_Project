using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyCamera : MonoBehaviourPun
{
    private AudioListener audioListener;
    private Camera playerCamera;
    void Start()
    {
        playerCamera = GetComponent<Camera>();
        audioListener = GetComponent<AudioListener>();
        if (!photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(false);
            audioListener.gameObject.SetActive(false);
        }
    }
}
