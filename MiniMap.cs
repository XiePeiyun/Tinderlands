using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    //拿到位置
    private RectTransform rectTransform;
    //拿到玩家位置
    private Transform player;
    //预制体
    private static Image item;
    //玩家图片
    private Image playerImage;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        item = Resources.Load<Image>("Image");

        if(player != null)
        {
            playerImage = Instantiate(item);
        }
    }

    private void Update()
    {
        ShowPlayer();
    }

    private void ShowPlayer()
    {
        playerImage.rectTransform.sizeDelta = new Vector2(50, 50);
        playerImage.rectTransform.anchoredPosition = new Vector2(0, 0);
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            playerImage.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (vertical < 0)
        {
            playerImage.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180f));
        }
        
        if (horizontal > 0)
        {
            playerImage.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
        }
        else if (horizontal < 0)
        {
            playerImage.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
        }

        playerImage.sprite = Resources.Load<Sprite>("Texture/Player");
        playerImage.transform.SetParent(transform, false);
    }

    public void ShowBox(Image image, float disX, float disY)
    {
        image.rectTransform.sizeDelta = new Vector2(30,30);
        image.rectTransform.anchoredPosition= new Vector2(disX*150,disY*150);
        //150/2=75
        image.sprite = Resources.Load<Sprite>("Texture/Box");
        image.transform.SetParent(transform, false);
    }

    public static Image create()
    {
        return Instantiate(MiniMap.item);
    }
}
