using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReward : Reward
{
    public enum RewardType { Rate, Ballistic };//射速和弹道

    public RewardType Type;

    public Transform players;
    public Transform heap;

    public override void GiveReward()
    {
        switch (Type)
        {
            case RewardType.Rate:
                {
                    PlayersController controller = players.GetComponent<PlayersController>();
                    controller.FireRate = base.rewardCoefficient * controller.FireRate;

                    break;
                }


        }


    }


    // Start is called before the first frame update
    void Start()
    {
        heap.GetComponent<LivingEntity>().DeathHandle += GiveReward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
