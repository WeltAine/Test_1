using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public abstract class Factory : MonoBehaviour
    {
        public abstract IProduct Produce();

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
