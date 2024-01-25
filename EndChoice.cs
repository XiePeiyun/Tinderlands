using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndChoice : MonoBehaviour
{
    public GameObject end3c1;
    public GameObject end3c11;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        end3c1.SetActive(true);
        end3c11.SetActive(true);
    }
}
