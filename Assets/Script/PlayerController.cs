using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Transform soliderGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane temPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        temPlane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        point.x = Mathf.Clamp(point.x, -7, 7);
        
        soliderGroup.Translate(new Vector3(point.x, soliderGroup.position.y, soliderGroup.position.z) - soliderGroup.position, Space.Self);
    }
}
