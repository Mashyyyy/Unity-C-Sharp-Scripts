using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBow : MonoBehaviour
{
    public GameObject arrowGO;
    public Transform arrowPoint;

    [SerializeField]
    private float fireRate;
    private float nextShot;

    private void Update()
    {
        if(GetComponentInParent<CharacterMove>().isInRangeOfEnemy && Time.time > nextShot && !GetComponentInParent<Health>().isAlreadyDead)
        {
            nextShot = Time.time + fireRate;
            Instantiate(arrowGO, arrowPoint.position, transform.rotation);
        }
    }
}