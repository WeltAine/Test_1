using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderReward : Reward
{
    public Transform players;
    public Transform parent;

    public override void GiveReward()
    {
        players.GetComponent<PlayersController>().SoliderNumber += base.rewardCoefficient;
    }


    // Start is called before the first frame update
    void Start()
    {
        //以触发器的方式毁坏并给与奖励（TakeHit将只会调用回调）
        //parent.GetComponent<LivingEntity>().DeathHandle += GiveReward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
