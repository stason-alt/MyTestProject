using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LVLManager : MonoBehaviour
{
    [Header("Tags")] [SerializeField] private string createTag;
    public int lvl;
    public GameObject text;
    public Controller controller;
    private GameObject obj;
    public float enemySpeedUp;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        CreateTag();
    }

    // Update is called once per frame
    void Update()
    {
        text = GameObject.FindGameObjectWithTag("LVLText");
        
        if (controller == null)
        {
            lvl++;
            enemySpeedUp += 0.1f;
        }
        
        LvlUp(); 
        controller = FindObjectOfType<Controller>();  
    }

    public void LvlUp()
    {
        text.GetComponent<TMP_Text>().text = $"LVL: {lvl.ToString()}";
    }
    void CreateTag()
    {
        obj = GameObject.FindWithTag(this.createTag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.createTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
}
