using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public abstract class Reward : MonoBehaviour
    {

        public Transform aim;//奖励对象

        public abstract void GiveReward();

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
