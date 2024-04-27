using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }
    }
    private void Fire()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if (bullet != null)
        {
            Ray target = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            bullet.transform.position = Camera.main.transform.position + new Vector3(0,3);
            bullet.SetActive(true);
        }
    }
}
