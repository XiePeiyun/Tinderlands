using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperUI : MonoBehaviour
{
    public Text uiText;
    internal string paperText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    public void OpenPaperUI(string text)
    {
        this.gameObject.SetActive(true);
        uiText.text = text;
    }

    public void ClickClose()
    {
        this.gameObject.SetActive(false);
    }
}
