using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManagerV2 : MonoBehaviour
{

    [SerializeField] private int lifeMax = 10;
    [SerializeField] private int life;
    [SerializeField] private SpriteMask mask;

    private void Start()
    {
        life = lifeMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        life -= 1;
        float amount = life / lifeMax;
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
