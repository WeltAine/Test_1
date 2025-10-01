using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class EnemyFactory : Factory
    {

        public EnemyGroup prefab;
        public override IProduct Produce()//???返回类型没法协变
        {
            //这个创建是可以的，但问题在于，创建出来的东西里头每一个组件的参数都是空的
            //当其中有一个参数为预制件引用时，这会导致不知道用什么
            {
                //GameObject newEnemyGroup = new GameObject("EnemyGroup (Clone)", typeof(EnemyGroup));
                //newEnemyGroup.transform.position = this.transform.position;
                //newEnemyGroup.GetComponent<EnemyGroup>().row = (int)(Random.Range(2, 7));
                //return newEnemyGroup.GetComponent<EnemyGroup>();
            }

            EnemyGroup newEnemys = GameObject.Instantiate(prefab, this.transform);
            newEnemys.row = (int)(Random.Range(4, 10));
            return newEnemys;

        }

        IEnumerator AutoProduce()
        {

            while (true)
            {
                IProduct produce = this.Produce();
                produce.Work();
                yield return new WaitForSeconds(3.0f);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            //StartCoroutine(AutoProduce());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
