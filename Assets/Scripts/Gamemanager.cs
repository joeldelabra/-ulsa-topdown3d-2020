
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

     [SerializeField]
     Player player;

    public Player Player { get => player; }

    void Awake() 
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }    
        DontDestroyOnLoad(gameObject);
    }
}