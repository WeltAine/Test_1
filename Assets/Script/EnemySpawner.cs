using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int row = 5;

    public Enemy enemyType;

    public void GenerateEnemys()
    {
        List<Enemy> enemys = new List<Enemy>();

        for(int x = 0; x < 7; x++)
        {
            for(int y = 0; y < row; y++)
            {
                Vector3 crood = CroodToVector3 (x, y);
                Enemy enemy = GameObject.Instantiate(enemyType, crood, Quaternion.identity);
                enemy.transform.SetParent(this.transform, false);
                enemys.Add(enemy);
            }
        }

        foreach (Enemy enemy in enemys) {
            enemy.state = Enemy.State.Move;
        }



    }

    public Vector3 CroodToVector3(int _x, int _y)
    {
        float x = -7 / 2.0f + 0.5f + _x;
        float y = -row / 2.0f + 0.5f + _y;

        return new Vector3(x, 0, y);//???以前从来没有想过，为什么值类型也要new呢
    }


    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
