using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public AudioClip OxygenClip;
    public float soundVol = 1.0f;
    public int amount = 1;
    //int collideCount;
    public ParticleSystem cureEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //collideCount++;
        Debug.Log($"吃到的物体是血包");

        ManController manController = other.GetComponent<ManController>();

        if (manController != null)
        {
            if (manController.health < manController.maxHealth)
            {
                manController.ChangeHealth(amount);
                //Destroy(gameObject);

                manController.PlaySound(OxygenClip, soundVol);
                //cure特效
                Instantiate(cureEffect,transform.position, Quaternion.identity);
            }
            else
            {

                //Destroy(gameObject);
                Debug.Log("当前角色氧气充足");
            }
        }
        

    }
}
