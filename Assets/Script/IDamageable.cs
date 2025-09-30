using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{

    //public virtual void TakeHit(float damage) { Debug.Log("HHH"); }//加了virtual和没加是一个效果，virtual不会起效果
    public void TakeHit(float damage);//有默认实现下派生可以不用管

    //public void TakeHit(float damage, GameObject attacter);
    
    
}
