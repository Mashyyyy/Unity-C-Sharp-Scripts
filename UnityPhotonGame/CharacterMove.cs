using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Rigidbody rb;

    //Just to Check if the Character is still Moving
    private bool isMoving;

    [SerializeField]
    private GameObject destination;

    [HideInInspector]
    public bool isInRangeOfEnemy;


    [Header("Values for AI Detection")]
    public float radius;
    public LayerMask layerMask;
    public float rotationSpeed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        destination = GameObject.FindGameObjectWithTag("Chara_Destination");
    }

    private void FixedUpdate()
    {
        if (!isInRangeOfEnemy)
        {
            agent.SetDestination(destination.transform.position);
            agent.isStopped = false;

        }
        else if (isInRangeOfEnemy)
            agent.isStopped = true;
    }

    private void Update()
    {
        Collider[] hitDetection = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hitDetection.Length > 0)
        {
            isInRangeOfEnemy = true;
            RotateCalculation();
        }
        else
        {
            isInRangeOfEnemy = false;
        }

        //AnimationControl();
        //AttackAnimationControl();
    }

    void AttackAnimationControl()
    {
        if (!isMoving)
        {
            anim.SetBool("isAttacking", true);
            if (agent.remainingDistance <= 1)
            {
                anim.SetBool("isAttacking", false);
            }
        }
        else if (isMoving)
        {
            anim.SetBool("isAttacking", false);
        }
    }


    void AnimationControl()
    {
        //For when detecting enemies
        if (!agent.isStopped)
        {
            anim.SetBool("isMoving", true);
            isMoving = true;
            if (agent.remainingDistance <= 1)
            {
                anim.SetBool("isMoving", false);
                isMoving = false;
            }
        }
        else if(agent.isStopped)
        {
            anim.SetBool("isMoving", false);
            isMoving = false;
        }
    }

    void RotateCalculation()
    {
        GameObject target = GameObject.FindGameObjectWithTag("EnemyUnit");
        Quaternion _lookRot;
        Vector3 _direction;

        _direction = (target.transform.position - transform.position).normalized;

        _lookRot = Quaternion.LookRotation(_direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRot, Time.deltaTime * rotationSpeed);
    }
}