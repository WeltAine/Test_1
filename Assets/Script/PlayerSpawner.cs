using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;


    public void GeneratePlayers(int number)
    {

    }

    public void SpawnerPlayer(int add)
    {

        for (int i = 0; i < add; i++)
        {
            EvaluateSpace();

            GameObject.Instantiate(playerPrefab, this.transform);
        }
        


        //var aim = this.transform.Find("Player");
        //aim.GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
    }


    /// <summary>
    /// 生成空间，避免生成士兵时出错
    /// </summary>
    public bool EvaluateSpace()
    {
        Collider[] aims = Physics.OverlapSphere(this.transform.position, 0.5f, LayerMask.GetMask("Player"));

        if(aims.Length == 0)
        {
            return true;
        }

        foreach(var aim in aims)
        {
            Vector3 direction = aim.transform.localPosition.normalized;
            if (Mathf.Approximately(direction.magnitude, float.Epsilon))
            {
                direction = Vector3.right;
            }
            Debug.Log(direction);
            aim.transform.Translate(direction * 0.5f, Space.World);

            Debug.Log(aim.transform.position);

        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
