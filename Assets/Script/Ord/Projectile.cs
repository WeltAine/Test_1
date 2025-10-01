using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask layerMask;

    public float damage = 1f;//子弹伤害

    public float velocity = 20f;//子弹射速

    private float currentDistance = 0f;//行程
    public Action<float, Projectile> RangeExceedHandle;//射程超出事件



    public void CheckCollision(float distance)
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        

        if(Physics.Raycast(ray, out hit, distance, layerMask, QueryTriggerInteraction.Ignore))
        {
            //LivingEntity aim = hit.collider.GetComponent<LivingEntity>() ?? null;
            IDamageable aim = hit.collider.GetComponent<IDamageable>() ?? null;
            aim?.TakeHit(damage);
            GameObject.Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()   
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = Time.deltaTime * velocity;
        CheckCollision(moveDistance);
        this.transform.Translate(this.transform.forward * moveDistance, Space.World);
        currentDistance += moveDistance;
        RangeExceedHandle?.Invoke(currentDistance, this);
    }
}
