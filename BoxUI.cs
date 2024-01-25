using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using Random = UnityEngine.Random;

public class BoxUI : MonoBehaviour
{
    public PaperButton paperButton;
    public GasButton gasButton;
    public StickButton stickButton;

    public string paperText;
    public bool isOxygen;
    public bool isToxic;
    public int numStick;
    public GameObject paperUI;

    public GameObject paper1;
    public ManController manController;
    public int addOxygen=1;
    public int addToxic=-3;
    public int health { get { return currentHealth; } }
    int currentHealth;
    public static BoxUI instance { get; private set; }


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        int value1 = Random.Range(0, 100);
        if (value1 <= 45)
        {
            isOxygen = false;
            isToxic = true;
        }
        else
        {
            isOxygen = true;
            isToxic = false;
        }

        int value2 = Random.Range(0, 100);
        if(value2 <= 30)
        {
            numStick = 0;
        }
        else if(value2 <= 70)
        {
            numStick = 1;
        }
        else
        {
            numStick = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickClose()
    {
        this.gameObject.SetActive(false);
    }

    public void ClickOk()
    {
        int index = 0;
        if (paperButton.isSelect)
        {
            index++;
            //收集该宝箱的纸张信息
        }
        
        if (stickButton.isSelect)
        {
            index++;
            //value2的信息 火柴盒本身剩余
        }
        
        if (gasButton.isSelect)
        {
            index++;
            //value1 氧气条本身剩余
        }

        if (index == 2)
        {
            if (paperButton.isSelect)
            {

                if (manController.bag < manController.maxBag)
                {
                    manController.ChangeBag(1);
                       
                }
                else
                {
                    Debug.Log("当前角色背包已满");
                }

                Inventory inventory = manController.GetComponent<Inventory>();
                if (inventory != null)
                {
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isfull[i] == false)
                        {
                            inventory.isfull[i] = true;
                            inventory.slots[i].GetComponent<Slot>().SetContent(paperText);
                            break;
                        }
                    }
                }
                paperButton.OnClick();
            }

            if (stickButton.isSelect)
            {
                manController.numStick = manController.numStick + numStick;
                stickButton.OnClick();
            }

            if (gasButton.isSelect)
            {
                if (isOxygen)
                {
                    manController.ChangeHealth(addOxygen);

                }
                else
                {
                    manController.ChangeHealth(addToxic);
                }
                gasButton.OnClick();
            }

            this.gameObject.SetActive(false);
        }
        else
        {
            paperUI.SetActive(true);
            paperUI.GetComponent<PaperUI>().paperText = paperText;
        }
    }


}
