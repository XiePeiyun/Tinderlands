using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxic : MonoBehaviour
{
    public AudioClip ToxicClip;
    public float soundVol = 1.0f;

    public int amount = -3;
    int collideCount;
    public ParticleSystem hitEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        collideCount++;
        Debug.Log($"碰撞毒气的物体是：{other},当前是第{collideCount}次碰撞!");

        ManController manController = other.GetComponent< ManController >();

        if (manController != null)
        {
            if (0 < manController.health)
            {
                manController.ChangeHealth(amount);
                Destroy(gameObject);

                //播放hit特效
                Instantiate(hitEffect, transform.position, Quaternion.identity);

                manController.PlaySound(ToxicClip, soundVol);
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("当前角色死亡");
            }
        }
        

    }
}
