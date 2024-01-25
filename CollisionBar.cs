using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CollisionBar : MonoBehaviour
{
    public enum Direction
    {
        up,
        right,
        left,
        down,
    }
    public Direction dir = Direction.up;

    public DirectionTips directionTips;
    public GameObject ConllsionBar;



    public char manDirection;
    public char ConllisionDirection;


    public void Start()
    {
        ConllsionBar = GetComponent<GameObject>();
    }

  

    private void Update()
    {
        if (manDirection == ConllisionDirection) 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    public void FixUpdate()
    {
        
    }

}
