using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class SoliderHeapFactory : Factory
    {

        public SoliderHeap heapPrefab;
        public SoliderReward soliderReward;


        public override IProduct Produce()
        {
            SoliderHeap newHeap = GameObject.Instantiate(heapPrefab, this.transform);
            SoliderReward newReward = GameObject.Instantiate(soliderReward, newHeap.transform);
            newReward.increment = Random.Range(1, 3);
            newHeap.reward = newReward;

            return newHeap;

        }

        IEnumerator AutoProduce()
        {
            while (true)
            {

                IProduct produce = this.Produce();
                produce.Work();
                yield return new WaitForSeconds(5.0f);
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
