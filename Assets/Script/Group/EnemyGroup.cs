using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;


namespace NewCode
{
    public class EnemyGroup : Group, IProduct
    {
        public int row;
        public Enemy enemyPrefab;

        public override void AddMembers(int increment)
        {
            row = increment;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < increment; y++)
                {
                    Vector3 crood = CroodToVector3(x, y);
                    Enemy enemy = GameObject.Instantiate(enemyPrefab, crood, Quaternion.identity);
                    enemy.transform.SetParent(this.transform, false);
                    base.members.Add(enemy.transform);
                }
            }

        }

        public Vector3 CroodToVector3(int _x, int _y)
        {
            float x = -7 / 2.0f + 0.5f + _x;
            float y = -row / 2.0f + 0.5f + _y;

            return new Vector3(x, 0, y);//???以前从来没有想过，为什么值类型也要new呢
        }

        public void Work()
        {
            AddMembers(row);
        }


        // Start is called before the first frame update
        void Start()
        {
            //AddMembers(row);
        }

        // Update is called once per frame
        void Update()
        {
            if (base.members.Count <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }

        }
    }
}
