using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire()
    {
        GameObject GunBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GunBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
