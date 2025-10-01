using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{

    public class LivingEntity : MonoBehaviour
    {

        public float health = 1.0f;
        public bool isDead = false;

        public event Action OnDeath;

        public virtual void OnDie()
        {
            OnDeath?.Invoke();
        }


    }

}
