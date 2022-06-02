using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    private void Start()
    {
        GetComponentInParent<Rigidbody>().AddForce(transform.forward * 700);
        Invoke("DestroyAfter", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().ModifyHealth(-15);
        Destroy(transform.parent.gameObject);
    }

    void DestroyAfter()
    {
        Destroy(transform.parent.gameObject);
    }
}