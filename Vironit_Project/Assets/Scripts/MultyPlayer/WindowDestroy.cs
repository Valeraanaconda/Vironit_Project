using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
