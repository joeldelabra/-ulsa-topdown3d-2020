sing System.Collections;
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

    
    Animator anim;

    [SerializeField]
    GameObject weapon;

    void Awake() 
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start() 
    {
        WeaponVisible(false);
    }


    void Update() 
    {
        if(Attack)
        {
            if(!Gamemanager.instance.IsInCombat)
            {
                 Gamemanager.instance.IsInCombat = true;
            }
            navMeshAgent.destination = Gamemanager.instance.Player.transform.position;
            transform.LookAt(Gamemanager.instance.Player.transform);
        }
        else
        {
            navMeshAgent.destination = transform.position;

            if(StopCombat && Gamemanager.instance.IsInCombat)
            {
                Gamemanager.instance.IsInCombat = false;
                anim.SetLayerWeight(0, 1);
                anim.SetLayerWeight(1, 0);
                Gamemanager.instance.StopCombat();
                WeaponVisible(false);
            }

            if(Gamemanager.instance.IsInCombat)
            {
                Gamemanager.instance.StartCombat();
                anim.SetLayerWeight(1, 1);
                WeaponVisible(true);
            }
        }
    }

    void LateUpdate() 
    {
         anim.SetBool("run", Attack); 
    }

    bool StopCombat
    {
        get => !(distanceBtwPlayer <= minDistance);
    }

    bool Attack
    {
        get => !StopCombat && distanceBtwPlayer> navMeshAgent.stoppingDistance;
    }

    float distanceBtwPlayer
    {
        get => Vector3.Distance(this.transform.position, Gamemanager.instance.Player.transform.position);
    }

    void WeaponVisible(bool visible)
    {
        weapon.SetActive(visible);
    }

}