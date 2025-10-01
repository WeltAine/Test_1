using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public interface IDamageable
    {

        public void TakeHit(float damage, GameObject attacker);//基于伤害来源产生不同特别的反馈
        public void TakeHit(float damage);//通用受伤反馈

    }
}

//???
//接口中所有使用virtual或者abstact是没有意义的，编译器大概率会忽略他们（写了virtual就必须写默认实现，这个原因类比C++的纯虚和虚）
//接口中的方法是隐式abstract的（和上面矛盾）
//直接继承接口的类重写方法后会变为普通方法（我们可以在直接继承类中更改修饰符）
