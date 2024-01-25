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
        Debug.Log($"��ײ��Ƭ�������ǣ�{other},��ǰ�ǵ�{collideCount}����Ƭ!");

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
                Debug.Log("��ǰ��ɫ��������");
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
