using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StayButton : MonoBehaviour
{
    public Inventory inventory;
    public Text text;
    public GameObject end21;
    public GameObject end21Text;
    public GameObject end22Text;
    public GameObject end23Text;
    //public TextMeshProUGUI end21Text;
   // public TextMeshProUGUI end22Text;
    //public TextMeshProUGUI end23Text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        end21.SetActive(true);
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
            end21Text.SetActive(true);
            //end21Text.text = "When will the treasure be exhausted?The years are really too long...";
        }

        if (0 < count && count <= 2)
        {
            end22Text.SetActive(true);
            //end22Text.text = "I returned to the underground palace and put the pieces I collected back into the box. Then go back to the starting point, stun yourself, and start all over again.\r\n\"When will the treasure be exhausted?\" The years are really too long...";
        }

        if (3 < count)
        {
            end23Text.SetActive(true);
            //end23Text.text = "I resolutely return to the dungeon and put my collection of shards back in the chest. Then back to the beginning, to disorientate myself and start all over again.\r\nOnly in the dungeon would I have a foothold, I would be the heir to the kingdom, I would be the saviour of the world, I would have it all.\r\nI will finally lie down in the dungeon with a clear conscience and go to my people as a brave warrior who fought but died valiantly.\r\n\"But when will the treasure be consumed?\" The years really are too long ......";
        }

        
    }
}
