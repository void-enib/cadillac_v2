using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pick the mouse's position in the scene, considering the transform as the origin
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        //angle between the x axis and the line which pass trough origin and diff, in degree
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //set rotation
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
