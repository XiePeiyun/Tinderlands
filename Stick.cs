using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public ManController manController;
    public float time = 5f;
    public float timer = 0f;

    public bool Dark = true;
    Animator Animator;
    public int amount = -2;
    int collideCount;

    Rigidbody2D rigidbody2d;

    private void OnEnable()
    {
        timer = 0f;
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= time)
        {
            //Show();
            manController.isStick = false;
            this.gameObject.SetActive(false);
            Dark = true;
        }
        else
        {
            this.gameObject.SetActive(true);
            Dark = false;
        }
        // Hide();
    }
    
    // public void Fire()
    // {
    //     this.gameObject.SetActive(true);
    //     manController.isStick = true;
    //     Dark = false;
    // }
}



