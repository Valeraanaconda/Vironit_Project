using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knob : MonoBehaviour
{
    public bool knob_close = false;
    public Animator knob_anim;
    void Start()
    {
        knob_anim = GetComponent<Animator>();
    }
    public void open_try(bool knob)
    {
        knob_close = !knob_close;
        knob_anim.SetBool("knob", knob_close);
    }

}
