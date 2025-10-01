using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class WeaponHeapFactory : Factory
    {
        public WeaponHeap heapPrefab;
        public WeaponReward weaponReward;


        public List<WeaponHeap> queue;
        public Transform startPoint;

        public override IProduct Produce()
        {
            WeaponHeap newWeaponHeap = GameObject.Instantiate(heapPrefab, this.transform);

            WeaponReward newReward = GameObject.Instantiate(weaponReward, newWeaponHeap.transform);
            //newReward.rewardParameters.damage = Random.Range(1, 3);
            newReward.rewardParameters.fireRate = Random.Range(1, 3);
            newReward.rewardParameters.range = Random.Range(0, 5);

            newWeaponHeap.reward = newReward;
            newWeaponHeap.OnDeath += ElementDieHandle;

            queue.Add(newWeaponHeap);

            return newWeaponHeap;

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

        public void ElementDieHandle()
        {
            queue.RemoveAt(0);

            IProduct produce = this.Produce();
            produce.Work();
            Vector3 aimPoint = startPoint.position + (8 * 7 * Vector3.forward);
            aimPoint.y = (produce as WeaponHeap).transform.position.y;
            (produce as WeaponHeap).transform.position = aimPoint;

            foreach(var aim in queue)
            {
                aim.Move();
            }

        }

        // Start is called before the first frame update
        void Start()
        {
            for(int i = 0; i < 8; i++)
            {
                IProduct produce = this.Produce();
                produce.Work();
                Vector3 aimPoint = startPoint.position + (i * 7 * Vector3.forward);
                aimPoint.y = (produce as WeaponHeap).transform.position.y;
                (produce as WeaponHeap).transform.position = aimPoint;

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
