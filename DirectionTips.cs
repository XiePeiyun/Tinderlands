using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DirectionTips : MonoBehaviour
{
    public enum Direction
    {
        up,
        right,
        left,
        down,
    }

    public Direction dir = Direction.up;
    // Start is called before the first frame update
    public GameObject tipsUI;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Wall")|| col.CompareTag("Box"))
        {
            // GetComponent<SpriteRenderer>().color = Color.red;
            // tipsUI.GetComponent<Image>().color = Color.red;
            tipsUI.SetActive(true);
            Debug.Log("当前方向有碰撞" + dir);
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Wall") || col.CompareTag("Box"))
        {
            // GetComponent<SpriteRenderer>().color = Color.white;
            // tipsUI.GetComponent<Image>().color = Color.white;
            tipsUI.SetActive(false);
        }
    }



    // private void OnCollisionEnter(Collision collision)
    // {
    //     GetComponent<SpriteRenderer>().color = Color.red;
    //     Debug.Log("当前方向有碰撞" + dir);
    // }
    //
    // private void OnCollisionEnter(Collision collision)
    // {
    //     GetComponent<SpriteRenderer>().color = Color.white;
    // }
}
