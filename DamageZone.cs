using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int amount = -3;
    void OnTriggerStay2D(Collider2D other)
    {
        ManController mancontroller = other.GetComponent<ManController>();

        if (mancontroller != null)
        {
            mancontroller.ChangeHealth(amount);
        }
    }

}
