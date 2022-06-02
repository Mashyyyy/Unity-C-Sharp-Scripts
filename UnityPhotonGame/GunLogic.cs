using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public ParticleSystem _particleSystem;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    [SerializeField]
    private float fireRate = 0.2f;
    private float nextFire = 0f;

    private CharacterMove chara;
    private EnemyMove enemyChara;

    private void Start()
    {
        chara = GetComponentInParent<CharacterMove>();
    }


    private void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent(out Health health))
        {
            health.ModifyHealth(-10);
        }
    }

    
    private void Update()
    {
        if (chara.isInRangeOfEnemy && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            _particleSystem.Play();
        }
    }
}