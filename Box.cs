using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isOpen;
    public float rangeRadius;
    public LayerMask layerMask;
    public GameObject boxUi;

    
    Rigidbody2D rigidbody2D;
    Animator Animator;
    bool Locked = true;

    public ParticleSystem smokeEffect;
    public string paperText;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (!Locked)
        {
            return;
        }
        
    }


    
    public void Open()
    {
        if (isOpen)
        {
            return;
        }
        else
        {
            isOpen = true;
            Locked = false;
            smokeEffect.Stop();
            boxUi.SetActive(true);
            boxUi.GetComponent<BoxUI>().paperText = paperText;
        }
        
    }
}
