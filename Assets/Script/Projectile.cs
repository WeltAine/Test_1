using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class Projectile : MonoBehaviour
    {

        public LayerMask layerMask;

        public float damage;
        public float velocity = 20f;//子弹速度

        private float currentDistance = 0f;//行程
        public Action<float, Projectile> OnRangeExceed;//射程超出事件
        //public Action<IDamageable> OnDamage;


        public void CheckCollision(float distance)
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, distance, layerMask, QueryTriggerInteraction.Ignore))
            {
                IDamageable aim = hit.collider.GetComponent<IDamageable>() ?? null;
                //OnDamage?.Invoke(aim);
                aim?.TakeHit(damage);
                GameObject.Destroy(this.gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float moveDistance = Time.deltaTime * velocity;
            CheckCollision(moveDistance);
            this.transform.Translate(this.transform.forward * moveDistance, Space.World);
            currentDistance += moveDistance;
            OnRangeExceed?.Invoke(currentDistance, this);

        }
    }
}
