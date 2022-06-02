using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class Health : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    public event Action<float> onHealthPctChanged = delegate { };

    [HideInInspector]
    public bool isAlreadyDead = false;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        onHealthPctChanged(currentHealthPct);

        Die();
    }

    void Die()
    {
        if(currentHealth <= 0)
        {
            if (!isAlreadyDead)
            {
                /*
                GetComponent<Animator>().SetTrigger("isDead");
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                Invoke("Destroy", 2f);
                isAlreadyDead = true;
                */
                Destroy();
            }
        }
    }

    void Destroy()
    {
        PhotonNetwork.Destroy(this.gameObject);
    }
}