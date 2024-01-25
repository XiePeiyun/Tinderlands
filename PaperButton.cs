using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperButton : MonoBehaviour
{
    public bool isSelect;
    public Sprite empty;
    public Sprite select;
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
        isSelect = !isSelect;
        if (isSelect)
        {
            GetComponent<Image>().sprite = select;
        }
        else
        {
            GetComponent<Image>().sprite = empty;
        }
    }
}
