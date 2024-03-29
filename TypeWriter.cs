using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public GameObject nextBottom;

    [Header("打字速度")]
    public float Speed = 15;

    TextMeshProUGUI text;

    void Start()
    {
        nextBottom.SetActive(false);
        text = this.GetComponent<TextMeshProUGUI>();
        Run(text.text, text);
    }
    public void Run(string textToType, TextMeshProUGUI textLabel)
    {
        StartCoroutine(TypeText(textToType, textLabel));
    }
    IEnumerator TypeText(string textToType, TextMeshProUGUI textLabel)
    {
        float t = 0;//经过的时间
        int charIndex = 0;//字符串索引值
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * Speed;//简单计时器赋值给t
            charIndex = Mathf.FloorToInt(t);//把t转为int类型赋值给charIndex
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToType;
        nextBottom.SetActive(true);
    }

}
