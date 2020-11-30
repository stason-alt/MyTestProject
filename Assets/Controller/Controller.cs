using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller :MonoBehaviour
{
    public BoxController boxController;
    private void Update()
    {
        if (boxController.boxes == null)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}