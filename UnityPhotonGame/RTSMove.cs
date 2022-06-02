using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RTSMove : MonoBehaviour
{
    private RaycastHit hitInfo;
    private Ray ray;

    public NavMeshAgent agent;

    public Camera _camera;
    private void Start()
    {
        ray = _camera.ScreenPointToRay(Input.mousePosition);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Click");
            if(Physics.Raycast(ray, out hitInfo, 500))
            {
                Debug.Log("SetDestination");
                agent.SetDestination(Input.mousePosition);
            }
            
        }
    }
}