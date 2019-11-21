using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class move_balle : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, speed, 0.0f);

    }
}