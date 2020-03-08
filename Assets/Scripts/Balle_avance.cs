using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle_avance : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform Direction1;
    Vector2 Direction;
    public int Xmin;
    public int Xmax;
    public int Ymin;
    public int Ymax;
    int a;
    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Direction.x = Direction1.position.x;
        Direction.y= Direction1.position.y;
        Debug.Log(transform.position);
        transform.Translate(Direction.normalized * speed * Time.deltaTime);
        //if (transform.position.x == 0)
        //{ }
        //else if (((transform.position.x < Xmin) || (transform.position.x > Xmax)) && Time.time > 1)
        //{ Destroy(gameObject); }
        //else if (((transform.position.y < Ymin) || (transform.position.y > Ymax)) && Time.time > 1)
        //{ Destroy(gameObject); }
        a = 0;
    }
}
