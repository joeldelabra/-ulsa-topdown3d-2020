﻿using System.Collections;
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


    [SerializeField]
    Animator anim;


    void Awake() 
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update() 
    {
        
        if(Attack)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            navMeshAgent.destination = Gamemanager.instance.Player.transform.position;
            transform.LookAt(Gamemanager.instance.Player.transform);
        }
        else
        {
            navMeshAgent.destination = transform.position;
        }
    }

    void LateUpdate() 
    {
         anim.SetBool("run", Attack);    
    }


    bool Attack
    {
         get => distanceBtwPlayer <= minDistance && distanceBtwPlayer > navMeshAgent.stoppingDistance;
    }
 float distanceBtwPlayer
    {
        get => Vector3.Distance(this.transform.position, Gamemanager.instance.Player.transform.position);
    }


}