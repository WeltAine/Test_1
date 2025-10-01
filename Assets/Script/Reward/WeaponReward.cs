using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class WeaponReward : Reward
    {

        public Gun.GunParameters rewardParameters;

        public event Action<Gun.GunParameters> OnGiveReward;

        public override void GiveReward()
        {
            Debug.Log("Give Gun Reward");
            OnGiveReward?.Invoke(rewardParameters);
        }

        // Start is called before the first frame update
        void Start()
        {
            base.aim = GameObject.Find("Level/SoliderGroup").transform;
            OnGiveReward += aim.GetComponent<SoliderGroup>().ModifyAllGun;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
