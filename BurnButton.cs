using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BurnButton : MonoBehaviour
{
    public Inventory inventory;
    public Text text;
    public GameObject end31;
    public GameObject end31Text;
    public GameObject end32Text;
    public GameObject end33Text;
    //public TextMeshProUGUI end31Text;
    //public TextMeshProUGUI end32Text;
    //public TextMeshProUGUI end33Text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {

        end31.SetActive(true);
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
            end31Text.SetActive(true);
            //end31Text.text = "I lit all the matches.";
        }

        if (0 < count && count <= 2)
        {
            end32Text.SetActive(true);
            //end32Text.text = "I lit all the matches, and eventually myself, and the flames burned throughout the dungeon.";
        }

        if (3 < count)
        {
            end33Text.SetActive(true);
            //end33Text.text = "I lit all the matches, and finally myself, and the flames burned up the entire dungeon in their wake. (In the corner, a matchbox blazed ......)";
        }

        
    }
}
