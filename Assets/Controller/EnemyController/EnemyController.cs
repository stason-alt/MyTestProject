using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    
    public GameObject enemyPref;
    public float speed;
    public LVLManager lvlManager;

    private void Awake()
    {
        lvlManager = FindObjectOfType<LVLManager>();
        CreateSinglton();
    }

    private void Start()
    {
        Instantiate(enemyPref, transform.position, transform.rotation);
        speed = 0.5f + lvlManager.enemySpeedUp;
    }
    
    
    
    private void CreateSinglton()
    {
        instance = this;
    }
}
