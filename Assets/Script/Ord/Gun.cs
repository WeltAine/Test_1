using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Projectile bulletPrefab;//子弹预制件
    public Transform bulletSpawnerPoint;//发射点


    public float FireRate { get { return fireRate; } set { fireRate = value; fireInterval = 1 / fireRate; } }
    [SerializeField]
    private float fireRate = 5.0f;//开火频率
    private float fireInterval;//开火间隔 

    public float range;

    public void Fire()
    {

        Projectile bullet = GameObject.Instantiate( bulletPrefab, bulletSpawnerPoint.position, bulletSpawnerPoint.rotation );
        bullet.RangeExceedHandle += OnRangeExceed;

    }

    public void OnRangeExceed(float currentDistance, Projectile bullet)
    {
        if (currentDistance > this.range)
        {
            GameObject.Destroy(bullet.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoFire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    private void OnValidate()
    {
        FireRate = fireRate;
    }
}
