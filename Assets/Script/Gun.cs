using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class Gun : MonoBehaviour
    {

        public Projectile bulletPrefab;//子弹预制件
        public Transform bulletSpawnerPoint;//发射点

        public float Damage { get; set; } = 1.0f;
        public float FireRate
        {
            get
            {
                return parameters.fireRate;
            }

            set
            {
                parameters.fireRate = value;
                parameters.fireInterval = 1 / parameters.fireRate;
            }
        }

        public float Range
        {
            get{ 
                return parameters.range;
            }

            set
            {
                parameters.range = value;
            }
        }

        [Serializable]
        public struct GunParameters
        {
            public float damage;
            public float fireRate;//开火间隔 
            public float fireInterval;//开火间隔 
            public float range;
        }
        [SerializeField]
        public GunParameters parameters;


        public void Fire()
        {
            Projectile bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnerPoint.position, bulletSpawnerPoint.rotation);
            bullet.OnRangeExceed += RangeExceedHandle;
            bullet.damage = this.Damage;
            //bullet.OnDamage += DamageHandle;

        }

        //TODO:自动开火
        public IEnumerator AutoFire()
        {

            while (true)
            {
                Fire();
                yield return new WaitForSeconds(parameters.fireInterval);
            }

        }

        public void RangeExceedHandle(float currentDistance, Projectile bullet)
        {
            if (currentDistance > this.Range)
            {
                GameObject.Destroy(bullet.gameObject);
            }
        }

        //public void DamageHandle(IDamageable aim)
        //{
        //    aim?.TakeHit(this.Damage);
        //}

        /// <summary>
        /// 更新参数
        /// </summary>
        /// <param name="newParameter"></param>
        public void UpdateParameters(GunParameters newParameter)//之后绑定给群事件
        {
            this.Damage = newParameter.damage;
            this.FireRate = newParameter.fireRate;
            this.Range = newParameter.range;
        }


        public void ModifyParameters(GunParameters newParameter)
        {
            this.Damage += newParameter.damage;
            this.FireRate += newParameter.fireRate;
            this.Range += newParameter.range;

        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateParameters(parameters);
            StartCoroutine(AutoFire());

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
