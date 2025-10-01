using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NewCode
{
    public class WeaponHeap : Heap, IMove, IProduct
    {
        public Transform boxPrefab;
        public Transform[,] boxs;//箱子


        public override void Generate()
        {
            Vector3 heapCenter = new Vector3(4.5f, heapHeight / 2.0f, this.transform.parent.transform.position.z);//这里之后要改
            this.transform.position = heapCenter;

            boxs = new Transform[heapWeight, heapHeight];
            //生成碰撞体
            BoxCollider heapCollider = this.AddComponent<BoxCollider>();
            heapCollider.size = new Vector3(heapWeight, heapHeight, 0);

            for (int x = 0; x < heapWeight; x++)
            {
                for (int y = 0; y < heapHeight; y++)
                {
                    Vector3 boxPosition = CroodToVector3(x, y);
                    boxs[x, y] = GameObject.Instantiate(boxPrefab, boxPosition, Quaternion.identity);

                    boxs[x, y].SetParent(this.transform, false);

                }
            }

        }

        public Vector3 CroodToVector3(int _x, int _y)
        {
            float x = -heapWeight / 2.0f + 0.5f + _x;
            float y = -heapHeight / 2.0f + 0.5f + _y;

            return new Vector3(x, y, 0);//???以前从来没有想过，为什么值类型也要new呢
        }

        public Tuple<int, int> IndexToCrood(int index)
        {
            int x = index % heapWeight;
            int y = (int)Mathf.Ceil((index + 1) / (float)heapWeight) - 1;

            Debug.Log($"{x}, {y}");
            return new Tuple<int, int>(x, y);
        }


        public override void OnDie()
        {
            Debug.Log("WeaponHeap is Die");

            base.OnDie();

            GameObject.Destroy(this.gameObject);
        }

        public override void TakeHit(float damage)
        {

            Debug.Log("WeaponHeap Call TakeHit");


            if (!base.isDead)
            {
                //删除方块
                var crood2D = IndexToCrood((int)health - 1);

                base.health -= damage;

                GameObject.Destroy(boxs[crood2D.Item1, crood2D.Item2].gameObject);

                if (base.health <= 0)
                {
                    base.isDead = true;
                    OnDie();
                }
            }

        }

        IEnumerator Rush()
        {
            float currentTime = 0.0f;

            while (currentTime < 1.0f)
            {
                this.transform.Translate(Vector3.forward * 7 * Time.deltaTime, Space.Self);
                currentTime += Time.deltaTime;

                yield return null;
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            //Generate();
            //base.health = heapHeight * heapWeight;
        }

        // Update is called once per frame
        void Update()
        {
            //Move();
        }

        public void Move()
        {
            //this.transform.Translate(6 * Time.deltaTime * Vector3.forward);
            StartCoroutine(Rush());
        }

        public void Work()
        {
            base.health = heapHeight * heapWeight;
            Generate();
        }
    }
}
