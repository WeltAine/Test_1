using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 生命实体
/// </summary>
public class LivingEntity : MonoBehaviour, IDamageable
{

    public float health = 1;
    public bool isDead = false;


    public event Action DeathHandle;//死亡广播


    public virtual void OnDie()
    {
        DeathHandle?.Invoke();
    }

    public virtual void TakeHit(float damage)//???显示实现不能设置可见性，而且没有多态
                                              //!!!C#接口的“多态”有点特别，它只有“一层的范围”，C#中常见的多态形式是基于virtual或abstruct方法的。
                                              //但是virtual概念的定义是“我有一个实现，但派生类可以改变它”。而接口是契约，是不会有实现的（尽管8.0加入了默认实现），而override表明“我正在替换基类的实现”
                                              //抽象方法没有实现，但是接口可以有默认实现
                                              //所以我们先前的一系列尝试都失败了
    {
        Debug.Log("LivingEntity Call TakeHit");

        if (!isDead)
        {
            health -= damage;
            if (health <= 0)
            {
                isDead = true;
                OnDie();
            }
        }
    }


    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}


    //// Update is called once per frame
    //void Update()
    //{
        
    //}

}
