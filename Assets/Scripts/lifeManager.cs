using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeManager : MonoBehaviour
{
    public float maxLife = 10.0f;
    public Image healthBar;

    private float life;
    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(life==0.0f)
        {
            Destroy(gameObject);
        }

        float amount = life / maxLife;
        healthBar.fillAmount = amount;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            life -= 1.0f;
            Destroy(collision.gameObject);
            Debug.Log(life);
        }
    }

}
