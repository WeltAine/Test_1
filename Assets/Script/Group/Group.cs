using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewCode
{
    public abstract class Group : MonoBehaviour
    {

        public List<Transform> members;

        public abstract void AddMembers(int increment);//增加

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
