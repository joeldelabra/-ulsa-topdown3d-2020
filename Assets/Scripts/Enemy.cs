using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField, Range(0.1f,10f)]
  float moveSpeed;
  [SerializeField, Range(0f,10f)]
  float minDistance;

  void Update()
  {

  }

/*  public bool Attack
  {
      get => vecto3.Distance(this.transform.);
  }*/ 
}
