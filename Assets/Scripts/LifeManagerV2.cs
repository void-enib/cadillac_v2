using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManagerV2 : MonoBehaviour
{

    [SerializeField] private int life = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        life -= 1;
    }

    private void Update()
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        if(life<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
