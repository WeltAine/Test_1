using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHeapGenerator : LivingEntity
{

    public int heapWeight, heapHeight;
    public Vector3 heapCenter;//堆的中心
    public Transform[,] boxs;//箱子
    public GameObject boxPrefab;

    public BoxCollider collider;

    public void GeneratorHeap()
    {

        heapCenter = new Vector3(4.5f, heapHeight / 2.0f, 0);
        this.transform.position = heapCenter;

        boxs = new Transform[heapWeight, heapHeight];
        collider.size = new Vector3(heapWeight, heapHeight, 0);

        for (int x = 0; x < heapWeight; x++)
        {
            for (int y = 0; y < heapHeight; y++)
            {
                Vector3 boxPosition = CroodToVector3(x, y);
                GameObject box = GameObject.Instantiate(boxPrefab, boxPosition, Quaternion.identity);

                box.transform.SetParent(this.transform, false);

                boxs[x, y] = box.transform;
            }
        }

        //生成碰撞体


    }

    public Vector3 CroodToVector3(int _x, int _y)
    {
        float x = -heapWeight / 2.0f + 0.5f + _x;
        float y = -heapHeight / 2.0f + 0.5f + _y;

        return new Vector3(x, y, 0);//???以前从来没有想过，为什么值类型也要new呢
    }

    public Tuple<int, int> IndexToCrood(int index)
    {
        int x = index % heapWeight;
        int y = (int)Mathf.Ceil((index + 1) / (float)heapWeight) - 1;

        Debug.Log($"{x}, {y}");
        return new Tuple<int, int>(x, y);
    }


    public override void OnDie() 
    {
        Debug.Log("BoxHeap is Die");

        base.OnDie();

        GameObject.Destroy(this.gameObject);
    }

    public override void TakeHit(float damage){

        Debug.Log("BoxHeap Call TakeHit");


        if (!base.isDead)
        {
            //删除方块
            var crood2D = IndexToCrood((int)health - 1);

            base.health -= damage;

            GameObject.Destroy(boxs[crood2D.Item1, crood2D.Item2].gameObject);

            if (base.health <= 0)
            {
                base.isDead = true;
                OnDie();
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        GeneratorHeap();

        base.health = heapWeight * heapHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


