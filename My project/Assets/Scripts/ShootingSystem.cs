using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = Camera.main.transform.position;
            bullet.SetActive(true);
            bullet.transform.rotation = Quaternion.LookRotation(ray.direction);

        }
    }
}
