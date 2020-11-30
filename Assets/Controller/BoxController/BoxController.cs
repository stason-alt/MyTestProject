using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GameObject;
using UnityEngine.SceneManagement;

public class BoxController : MonoBehaviour
{
    public GameObject boxPref;
    public GameObject[] boxes;
    public GameObject[] boxesPos;

    private void Start()
    {
        boxesPos = FindGameObjectsWithTag("BoxPos");
        InstantiateBox();
    }

    private void Update()
    {
        boxes = FindGameObjectsWithTag("Box");
        if (boxes.Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void InstantiateBox()
    {
        for (int i = 0; i <= boxesPos.Length; i++)
        {
            var pos = boxesPos[i].transform.position;
            var rot = boxesPos[i].transform.rotation;
            
            Instantiate(boxPref);
            
            boxPref.transform.position = pos;
            boxPref.transform.rotation = rot;
        }
    }
}
