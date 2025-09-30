using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    public enum State { Idle, Move}
    public State state = State.Idle;

    public float moveSpead = 5.0f;

    public override void OnDie()
    {
        base.OnDie();

        GameObject.Destroy(this.gameObject);
    }

    public void Move()
    {
        this.transform.Translate(moveSpead * Time.deltaTime * Vector3.forward);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Move)
        {
            Move();
        }
    }
}
