using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    [RequireComponent(typeof(Rigidbody))]
    public class Solider : LivingEntity, IDamageable
    {
        public Gun gun;

        public override void OnDie()
        {
            base.OnDie();//使用回调
            this.transform.parent.GetComponent<SoliderGroup>().OnModifyGun -= gun.ModifyParameters;
            this.transform.parent.GetComponent<SoliderGroup>().members.Remove(this.transform);
            GameObject.Destroy(this.gameObject);//销毁自己
            
        }

        public void TakeHit(float damage, GameObject attacker)
        {
            TakeHit(damage);
        }

        public void TakeHit(float damage)
        {
            Debug.Log("Solider Call TakeHit");

            if (!isDead)
            {
                health -= damage;
                if (health <= 0)
                {
                    isDead = true;
                    OnDie();
                }
            }
            
        }


        // Start is called before the first frame update
        void Start()
        {
            gun = this.GetComponentInChildren<Gun>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        

    }
}
