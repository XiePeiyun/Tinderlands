using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    
    public GameObject endRoot;
    public GameObject endScreen;
    public GameObject endText;
    public LayerMask layerMask;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log($"ÕÒµ½³ö¿Ú£¡");

        ManController manController = other.gameObject.GetComponent<ManController>();

        if (manController != null)
        {
            manController.isEnd = true;
            OpenDoor();
        }


    }
    public void OpenDoor()
    {
        endRoot.SetActive(true);
        endScreen.SetActive(true);
        endText.SetActive(true);

        //endText.text = "I walked out and discovered that I was the last match of the \"Perfect Match.\" The world has become a lighter world, and I have no place to stand.\r\n      The little match turned into a little stick figure, raised his head and asked me: \"General, what should we do next?\"";



    }
}
