using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyMovement : MonoBehaviourPun
{

    public CharacterController controller;
    public float speed = 2f;
   
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
