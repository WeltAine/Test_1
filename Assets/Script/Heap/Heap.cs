using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public abstract class Heap : LivingEntity, IDamageable
    {
        public int heapHeight, heapWeight;

        public Reward reward;

        public virtual void TakeHit(float damage, GameObject attacker)
        {
            TakeHit(damage);
        }

        public virtual void TakeHit(float damage)
        {
            Debug.Log("Heap Call TakeHit");

            if (!isDead)
            {
                health -= damage;
                if (health <= 0)
                {
                    isDead = true;
                    reward.GiveReward();
                    OnDie();
                }
            }

        }

        public override void OnDie()
        {
            base.OnDie();

            reward.GiveReward();
        }

        public abstract void Generate();


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
