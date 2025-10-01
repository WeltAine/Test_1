using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class SoliderReward : Reward
    {

        public int increment = 0;

        public override void GiveReward()
        {
            aim.GetComponent<SoliderGroup>().AddMembers(increment);
        }

        // Start is called before the first frame update
        void Start()
        {
            base.aim = GameObject.Find("Level/SoliderGroup").transform;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
