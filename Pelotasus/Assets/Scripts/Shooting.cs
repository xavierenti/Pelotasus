using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50f;
    public bool mirandoDerecha;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);


        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bulletClone = Instantiate(bullet);
                bulletClone.transform.position = firePoint.position;
                bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                timeBtwShots = startTimeBtwShots;

                Destroy(bulletClone, 3);
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    
    
}
