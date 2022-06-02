using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogicEnemy : MonoBehaviour
{
    public ParticleSystem _particleSystem;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    [SerializeField]
    private float fireRate = 0.2f;
    private float nextFire = 0f;

    private EnemyMove enemyChara;

    private void Start()
    {
        enemyChara = GetComponentInParent<EnemyMove>();
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.ModifyHealth(-10);
        }
    }


    private void Update()
    {
        if (enemyChara.isInRangeOfEnemy && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            _particleSystem.Play();
        }
    }
}