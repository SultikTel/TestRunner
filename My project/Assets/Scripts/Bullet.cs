using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    

    // Start is called before the first frame update
    
    private void OnEnable()
    {
        rb.velocity = transform.forward * speed;
    }


}
