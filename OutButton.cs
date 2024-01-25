using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OutButton : MonoBehaviour
{
    public Inventory inventory;
    public Text text;
    public GameObject end11;
    public TextMeshProUGUI end11Text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        end11.SetActive(true);
        //根据碎纸片的数量拉起对应的界面

        GetComponent<Image>().color = Color.yellow;
        //验证背包里碎纸片的数量
        int count = 0;
        for (int i = 0; i < inventory.isfull.Length; i++)
        {
            if (inventory.isfull[i])
            {
                count++;
            }
        }
        
        if (count == 0)
        {
            end11Text.text = "You walked out and said goodbye to everything behind you...";
        }
        
        if (0< count && count<=2)
        {
            end11Text.text = "You walked out and said goodbye to everything behind you...";
        }
        
        if (3< count)
        {
            end11Text.text = "You walked out and said goodbye to everything behind you...";
        }
        
        
    }
}
