using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnNameObject : LivingEntity
{
    [Serializable]
    public enum State { Idle, Move}
    public State state = State.Move;


    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 1.0f, LayerMask.GetMask("Heap", "Default"), QueryTriggerInteraction.Collide))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        base.OnDie();

        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.GetComponentInChildren<SoliderReward>().GiveReward();
        }

        GameObject.Destroy(this.gameObject);
    }
}
