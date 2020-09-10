using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> points;
    private Animator anim;
    private AudioSource audio;

    public int curPoint;
    public float MainwhaitTime;
    private float whaitTime;
    public float rotationSpeed = 5f;

    public bool logic;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        whaitTime = MainwhaitTime;
        agent = GetComponent<NavMeshAgent>();
        curPoint = Random.Range(0, points.Count);
        logic = true;
    }


    void Update()
    {
        catLogic();
    }
    public void catLogic()
    {
        if (logic == true)
        {
            agent.SetDestination(points[curPoint].position);
            anim.SetBool("isMove", true);
            if (Vector3.Distance(points[curPoint].position, transform.position) < 0.5f)
            {
                if (whaitTime <= 0)
                {
                    anim.SetBool("isSit", false);

                    curPoint = Random.Range(0, points.Count);
                    whaitTime = MainwhaitTime;
                }
                else
                {
                    anim.SetBool("isSit", true);
                    whaitTime -= Time.deltaTime;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            logic = false;
            anim.SetBool("isSit", true);
            agent.speed = 0;
            Vector3 direction = other.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            logic = true;
            anim.SetBool("isSit", false);
            agent.speed = 1;

        }
    }
    public void sayMeay()
    {
        audio.Play();
    }
}
