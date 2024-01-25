using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public int paper = 1;
    public string text = "1231231241234";
    int collideCount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        collideCount++;
        Debug.Log($"碰撞碎片的物体是：{other},当前是第{collideCount}张碎片!");

        ManController manController = other.GetComponent<ManController>();

        if ( manController != null)
        {
            if (manController.bag < manController.maxBag)
            {
                manController.ChangeBag(paper);
                // Destroy(gameObject);
            }
            else
            {
                Debug.Log("当前角色背包已满");
            }
        }
        
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            for (int i = 0; i < inventory.slots.Length ; i++)
            {
                if (inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    inventory.slots[i].GetComponent<Slot>().SetContent(text);
                    Destroy(gameObject);
                    break;
                }
            } 
        }
    }
}
