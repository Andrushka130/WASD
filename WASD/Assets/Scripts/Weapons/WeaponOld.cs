using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOld : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireForce = 20f;
    public float timer;
    private float cooldown = 1f;

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

    public void automaticShooting()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            FireBullet();
            timer = 0;
        }
    }

    public void Update()
    {
        automaticShooting();
    }
}
