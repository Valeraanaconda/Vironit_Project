using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool IsOpen = false;
    public Animator open_door;
    void Start()
    {
        open_door = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = !IsOpen;
            open_door.SetBool("IsOpen",IsOpen);
        }
    }

}
