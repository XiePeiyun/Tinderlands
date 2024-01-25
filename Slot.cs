using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool hasItem = false;
    private bool hasRedDot = false;

    public GameObject itemIcon;
    public GameObject redDot;
    public PaperUI paperUI;

    public ManController manController;
    public Stick stick;

    [HideInInspector]
    public string content = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetContent(string text)
    {
        itemIcon.SetActive(true);
        redDot.SetActive(true);
        

        content = text;
        hasItem = true;
        hasRedDot = true;

    }


    public void ClickSlot()
    {
        if (!hasItem)
        {
            return;
        }
        
        if (hasRedDot)
        {
            if (!stick.Dark)
            {
                redDot.SetActive(false);
                hasRedDot = false;
                paperUI.OpenPaperUI(content);
            }
            else
            {
                
            }
        }
        else
        {
            paperUI.OpenPaperUI(content);
        }
    }
}
