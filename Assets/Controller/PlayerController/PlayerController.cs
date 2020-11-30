using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerPref;
    public GameObject player;
    void Start()
    {
        CreatPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
         if (player == null)
         {
             CreatPlayer();
         }
         OffPlayerScript();
    }

    public void CreatPlayer()
    {
        Instantiate(playerPref, transform.position,transform.rotation);
    }

    public void OffPlayerScript()
    {
        if (player.transform.position.x != 0)
        {
            player.GetComponent<Player>().enabled = false;
        }
        else
        {
            player.GetComponent<Player>().enabled = true;
        }
    }
}
