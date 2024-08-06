using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
   
    public bool iscolliding = false;
    public Transform target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            iscolliding = true;
        }
        if (iscolliding)
        {

            Debug.Log("You have DIED. Game OVER");
             
        }
    }
}
