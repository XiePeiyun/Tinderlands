using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   
    // ��ɫ�� Transform ���
    public Transform target;
    // ����ͽ�ɫ֮���ƫ����
    Vector3 offset;
    //ƽ��ֵ����ϣ���ƶ���̫��Ӳ
    public float smoothSpeed = 5f;
    void Start()
    {
        //�����������֮��Ĳ�
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ʵʱ�ƶ��ľ���
        Vector3 pos = transform.position;
        transform.position = target.position + offset;

        Vector3.Lerp(pos, transform.position, smoothSpeed * Time.deltaTime);
    }

}
