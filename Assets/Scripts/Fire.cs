using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    public float speed = 50f;
    public GameObject bulletPrefab;
    public Transform spawnBullet;

    public static event Action pistolFire;
    public void FireActivate()
    {
        GetComponent<AudioSource>().Play();
        GameObject createBullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = speed * spawnBullet.forward;
        Destroy(spawnBullet, 5f);
        pistolFire?.Invoke();
    }
}
