using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewCode
{
    public class Enemy : LivingEntity, IDamageable, IMove
    {

        public float moveSpead = 5.0f;

        public override void OnDie()
        {
            Debug.Log("Enemy is Die");

            base.OnDie();

            this.transform.parent.GetComponent<EnemyGroup>().members.Remove(this.transform);
            GameObject.Destroy(this.gameObject);
        }

        public void Move()
        {
            this.transform.Translate(moveSpead * Time.deltaTime * Vector3.forward);
        }



        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public void TakeHit(float damage, GameObject attacker)
        {
            TakeHit(damage);
        }

        public void TakeHit(float damage)
        {
            Debug.Log("Enemy Call TakeHit");

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

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer != this.gameObject.layer)
            {
                Debug.Log("ZZZ");
                collision.gameObject.GetComponent<IDamageable>().TakeHit(1, this.gameObject);
            }
        }
    }
}
