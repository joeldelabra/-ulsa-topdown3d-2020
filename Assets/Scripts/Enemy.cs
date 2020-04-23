using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    float moveSpeed;
    [SerializeField, Range(0.1f, 10f)]
    float minDistance;

    NavMeshAgent navMeshAgent;

    void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update() 
    {
        if(Attack)
        {
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            navMeshAgent.destination = Gamemanager.instance.Player.transform.position;
            transform.LookAt(Gamemanager.instance.Player.transform);
        }
    }

    bool Attack
    {
        get => Vector3.Distance(this.transform.position, Gamemanager.instance.Player.transform.position) <= minDistance;
    }

}