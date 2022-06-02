using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6) //6. Enemy Unit Layer
        {
            other.GetComponent<Health>().ModifyHealth(-25);
        }
    }
}