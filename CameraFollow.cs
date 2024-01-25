using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   
    // 角色的 Transform 组件
    public Transform target;
    // 相机和角色之间的偏移量
    Vector3 offset;
    //平滑值，不希望移动的太生硬
    public float smoothSpeed = 5f;
    void Start()
    {
        //摄像机到人物之间的差
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //实时移动的距离
        Vector3 pos = transform.position;
        transform.position = target.position + offset;

        Vector3.Lerp(pos, transform.position, smoothSpeed * Time.deltaTime);
    }

}
