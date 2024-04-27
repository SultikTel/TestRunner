using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {

            other.GetComponent<Enemy>().takeDamage(1);
        }
        
        StopAllCoroutines();
        gameObject.SetActive(false);
        
    }

    private void OnEnable()
    {
        StartCoroutine(GoesTooLong());
    }
    IEnumerator GoesTooLong()
    {
        yield return new WaitForSeconds(8);
        gameObject.SetActive(false);
    }

}
