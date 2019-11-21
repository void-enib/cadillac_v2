﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManager : MonoBehaviour
{
    public int life = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(life==0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            life--;
            Destroy(collision.gameObject);
            Debug.Log(life);
        }
    }

}
