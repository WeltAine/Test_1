using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewCode
{
    public class SoliderGroup : Group
    {

        public Transform soliderPrefab;

        public event Action<Gun.GunParameters> OnModifyGun;

        public void ModifyAllGun(Gun.GunParameters newParameter)
        {
            OnModifyGun?.Invoke(newParameter);
        }

        public override void AddMembers(int increment)
        {
            for (int i = 0; i < increment; i++)
            {
                EvaluateSpace();

                Transform solider = GameObject.Instantiate(soliderPrefab, this.transform);
                OnModifyGun += solider.GetComponent<Solider>().gun.ModifyParameters;
                base.members.Add(solider);
                solider.GetComponent<Solider>().gun.UpdateParameters(base.members[0].GetComponentInChildren<Gun>().parameters); //同步武器参数

            }

        }

        /// <summary>
        /// 生成空间，避免生成士兵时空间不足
        /// </summary>

        public bool EvaluateSpace()
        {
            Collider[] aims = Physics.OverlapSphere(this.transform.position, 0.5f, LayerMask.GetMask("Solider"));

            if (aims.Length == 0)
            {
                return true;
            }

            foreach (var aim in aims)
            {
                Vector3 direction = aim.transform.localPosition.normalized;

                if (Mathf.Approximately(direction.magnitude, float.Epsilon))
                {
                    //direction = Vector3.right;
                    Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
                    direction = new Vector3(randomDirection.x, 0, randomDirection.y);

                }

                Vector2 _randomDirection = UnityEngine.Random.insideUnitCircle.normalized * 0.2f;
                direction += new Vector3(_randomDirection.x, 0, _randomDirection.y);


                Debug.Log(direction);
                aim.transform.Translate(direction * 0.5f, Space.World);

                Debug.Log(aim.transform.position);

            }

            return false;
        }


        // Start is called before the first frame update
        void Start()
        {
            AddMembers(1);
        }

        // Update is called once per frame
        void Update()
        {
            if(base.members.Count <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }

        private void FixedUpdate()
        {
            foreach (Transform solider in this.transform)
            {
                solider.GetComponent<Rigidbody>().AddForce(-1 * solider.localPosition * 25);
            }
        }

    }
}
