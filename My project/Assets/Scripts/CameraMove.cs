using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player player;
    public Transform pointToLook;
    [SerializeField] private Vector3 offSet;

    private void Update()
    {
        transform.position = player.transform.position + offSet;
        if (pointToLook != null)
        {
            Vector3 lookDirection = pointToLook.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime);
        }
    }
}
