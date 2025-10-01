using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward : MonoBehaviour
{
    public int rewardCoefficient;//奖励系数

    public abstract void GiveReward();

}
