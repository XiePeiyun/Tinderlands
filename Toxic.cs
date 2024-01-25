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
        Debug.Log($"��ײ�����������ǣ�{other},��ǰ�ǵ�{collideCount}����ײ!");

        ManController manController = other.GetComponent< ManController >();

        if (manController != null)
        {
            if (0 < manController.health)
            {
                manController.ChangeHealth(amount);
                Destroy(gameObject);

                //����hit��Ч
                Instantiate(hitEffect, transform.position, Quaternion.identity);

                manController.PlaySound(ToxicClip, soundVol);
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("��ǰ��ɫ����");
            }
        }
        

    }
}
