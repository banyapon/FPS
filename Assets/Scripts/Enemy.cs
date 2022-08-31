using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform targetObject;
    public string tagObject;
    Animator animator;
    NavMeshAgent navAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        if (targetObject == null){
            targetObject = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.destination = targetObject.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == tagObject)
        {
            animator.SetTrigger("Death");
            Destroy(collision.gameObject);
            navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            navAgent.isStopped = true;
            StartCoroutine(clearObject());
        }
    }
    IEnumerator clearObject() {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
