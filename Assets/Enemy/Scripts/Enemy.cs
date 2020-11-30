using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public EnemyController enemyController;
    public EnemyController enemyController;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Move();
    }

    public void Move()
    { 
        GetComponent<Rigidbody>().velocity = new Vector3(player.transform.position.x,1,
            player.transform.position.z) * enemyController.speed ;
    }
    
}
