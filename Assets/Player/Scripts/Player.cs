using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Parametrs
{
    void Update()
    {
        SerchObject();
        Control();
        Force();
        NotArrow(false);
    }

    public void Control()
    {
        if (touch.downHandler)
        {
            currentDis = Vector3.Distance(pA.transform.position, transform.position);

            if (currentDis <= maxDis)
            {
                safeSp = currentDis;
            }
            else
            {
                safeSp = maxDis;
            }

            shootPow = Mathf.Abs(safeSp) * 14;

            Vector3 dimxy = pA.transform.position - transform.position;
            float dif = dimxy.magnitude;
            pB.transform.position = transform.position + ((dimxy / dif) * currentDis * -1);
            pB.transform.position = new Vector3(pB.transform.position.x,1,pB.transform.position.z);

            shootDir = Vector3.Normalize(pA.transform.position - transform.position);
            
            DoArrow(true);
            
        }
    }

   
}

public class Parametrs : MonoBehaviour
{
    #region Var
     public GameObject player;
     public GameObject pA;
     public GameObject pB;
     public GameObject Arrow;
        
     public TouchController touch;
    
     public float currentDis;
     public float maxDis;
     public float safeSp;
     public float shootPow;
       
     protected Vector3 shootDir;
#endregion
        
    #region Method
    public void Force()
    {
        if (touch.upHandler)
        {
            Vector3 push = shootDir * shootPow * -1 * 20;
            player.GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);
        }
    }
    
    public void NotArrow(bool enable)
    {
        if (touch.upHandler)
        {
            Arrow.GetComponent<Renderer>().enabled = enable;
            Arrow.transform.localScale = new Vector3(0f,0.1f,0f);
            Arrow.transform.position = new Vector3(0f,1f,2);
        }
    }
    
    public void DoArrow(bool enable)
        {
            Arrow.GetComponent<Renderer>().enabled = enable;
            if (currentDis <= maxDis)
            {
                 
                 Arrow.transform.position = new Vector3((2f * transform.position.x) - pA.transform.position.x,1f,
                     (2f * transform.position.z) - pA.transform.position.z);
            }
            else
            {
                 Vector3 dimxy = pA.transform.position - transform.position;
                 float dif = dimxy.magnitude;
                 Arrow.transform.position = transform.position + ((dimxy / dif) * maxDis * -1);
                 Arrow.transform.position = new Vector3(Arrow.transform.position.x,1f,Arrow.transform.position.z);
            }

            Vector3 dir = pA.transform.position - transform.position;
            float rot;
            if (Vector3.Angle(dir, transform.forward) > 90)
            {
                 rot = Vector3.Angle(dir, transform.right);
            }
            else
            {
                 rot = Vector3.Angle(dir, transform.right) * -1;
            }
            Arrow.transform.eulerAngles = new Vector3(0,rot,0);
            float scalex = Mathf.Log(1+ safeSp/2,2) * 0.1f;
            float scalez = Mathf.Log(1+ safeSp/2,2) * 0.1f;
            Arrow.transform.localScale = new Vector3(  0.2f + scalez,1f, scalex);
        }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Box"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.collider.CompareTag("Enemy"))       
        { 
            Destroy(gameObject);       
        }
    }

    public void SerchObject()
    {
        if (pA == null || pB == null || touch == null || Arrow == null || player == null)
        {
            touch = FindObjectOfType<TouchController>();
            pA = GameObject.FindGameObjectWithTag("pivotA");
            pB = GameObject.FindGameObjectWithTag("pivotB");
            Arrow = GameObject.FindGameObjectWithTag("Arrow");
            player = GameObject.FindGameObjectWithTag("Player");
        } 
    }
    #endregion
}
