using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{

    public class GameManager : MonoBehaviour
    {

        public SoliderHeapFactory shFactory;
        public EnemyFactory enemyFactory;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(MakeProduce());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator MakeProduce()
        {
            while (true)
            {

                int mode = Random.Range(0, 2);

                switch (mode)
                {
                    case 0:
                        {

                            IProduct produce = shFactory.Produce();
                            produce.Work();
                            break;

                        }

                    default:
                        {
                            IProduct produce = enemyFactory.Produce();
                            produce.Work();
                            break;

                        }
                }

                yield return new WaitForSeconds(3.0f);
            }
        }

    }
}
