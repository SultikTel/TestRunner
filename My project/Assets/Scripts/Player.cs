using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Player : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navMeshAgent;
    public Action<bool> onStatusChanged;
    Vector3 nextPointToLookAt;

    private bool isWalking;



    // Update is called once per frame
    private void Update()
    {
        if (navMeshAgent.remainingDistance < 2f && isWalking == true && navMeshAgent.velocity.magnitude < 0.15f)
        {
            Arrived();
        }

        if (nextPointToLookAt != null)
        {
            Vector3 lookDirection = nextPointToLookAt - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime);
        }
    }

    public void ChangePlace(Vector3 newPlace)
    {   
        StartCoroutine(WaitOneMoment(newPlace));      
    }

    IEnumerator WaitOneMoment(Vector3 newPlace)
    {
        navMeshAgent.SetDestination(newPlace);
        yield return new WaitForSeconds(0.1f);
        isWalking = true;
        onStatusChanged?.Invoke(isWalking);
    }


    public void Arrived()
    {
        
        isWalking = false;
        onStatusChanged?.Invoke(isWalking);
    }

    

    public void changeLookPoint(Vector3 pos)
    {
        nextPointToLookAt = pos;
    }
}
