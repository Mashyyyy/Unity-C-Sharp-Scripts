using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) //7. Player Unit Layer
        {
            other.GetComponent<Health>().ModifyHealth(-25);
        }
    }
}