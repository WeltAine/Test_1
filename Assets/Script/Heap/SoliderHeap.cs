using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NewCode
{
    public class SoliderHeap : Heap, IMove, IProduct
    {
        public float moveSpeed = 4.0f;

        public Transform boxPrefab;

        public override void Generate()
        {
            Vector3 heapCenter = new Vector3(-4.25f, 1.0f, this.transform.parent.transform.position.z);
            this.transform.position = heapCenter;

            BoxCollider heapCollider = this.AddComponent<BoxCollider>();
            heapCollider.size = new Vector3(7.5f, 2, 0);
            heapCollider.isTrigger = true;

            GameObject.Instantiate(boxPrefab, this.transform);
        }

        public override void OnDie()
        {
            Debug.Log("SoliderHeap is Die");

            base.OnDie();

            GameObject.Destroy(this.gameObject);
        }

        public override void TakeHit(float damage, GameObject attacker)
        {
            Debug.Log("SoliderHeap Call TakeHit");

            if (attacker.layer == LayerMask.NameToLayer("Solider"))
            {
                if (!base.isDead)
                {
                    base.health -= damage;

                    if (base.health <= 0)
                    {
                        base.isDead = true;
                        OnDie();
                    }
                }

            }
            else
            {
                if (!base.isDead)
                {
                    base.health -= damage;

                    if (base.health <= 0)
                    {
                        base.isDead = true;
                        GameObject.Destroy(this.gameObject);
                    }
                }

            }
        }

        public override void TakeHit(float damage)
        {

            Debug.Log("SoliderHeap Call TakeHit");


            if (!base.isDead)
            {
                base.health -= damage;

                if (base.health <= 0)
                {
                    base.isDead = true;
                    OnDie();
                }
            }

        }


        // Start is called before the first frame update
        void Start()
        {
            //Generate();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            //TODO:记得去调整碰撞矩阵
            TakeHit(1, other.gameObject);
        }

        public void Move()
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit, 1.0f, LayerMask.GetMask("SoliderHeap"), QueryTriggerInteraction.Collide))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
            }

        }

        public void Work()
        {
            Generate();
        }
    }
}
