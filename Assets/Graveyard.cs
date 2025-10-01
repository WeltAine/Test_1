using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public class Graveyard : MonoBehaviour
    {
        public LayerMask layerMask;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("HHH");

            if (((1 << other.gameObject.layer) | layerMask) == layerMask.value)
            {
                other.gameObject.GetComponent<IDamageable>().TakeHit(10000, this.gameObject);
            }
        }
    }
}
