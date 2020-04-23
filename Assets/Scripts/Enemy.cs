using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField, Range(0.1f,10f)]
  float moveSpeed;
  [SerializeField, Range(0.1f,10f)]
  float minDistance;

  void Update()
  {
    if(Attack)
    {
      transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
      transform.LookAt(Gamemanager.instance.Player.transform);

    }
  }

bool Attack
  {
      get => Vector3.Distance(this.transform.position, Gamemanager.instance.Player.transform.position) <= minDistance;
  }
}
