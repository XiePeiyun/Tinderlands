using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter2 : MonoBehaviour
{
    [Header("�����ٶ�")]
    public float Speed = 15;

    TextMeshProUGUI text;
    
    private void OnEnable()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        Run(text.text, text);
    }

    public void Run(string textToType, TextMeshProUGUI textLabel)
    {
        StartCoroutine(TypeText(textToType, textLabel));
    }
    IEnumerator TypeText(string textToType, TextMeshProUGUI textLabel)
    {
        float t = 0;//������ʱ��
        int charIndex = 0;//�ַ�������ֵ
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * Speed;//�򵥼�ʱ����ֵ��t
            charIndex = Mathf.FloorToInt(t);//��tתΪint���͸�ֵ��charIndex
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToType;
    }
}
