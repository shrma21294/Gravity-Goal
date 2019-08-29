using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	NavMeshAgent agent; //Unity will automatically add NavMeshAgent when you use this component
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void moveToPoint(Vector3 point){
    	agent.SetDestination(point);
    }
}
