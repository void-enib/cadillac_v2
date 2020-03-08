using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire_1 : MonoBehaviour
{
    //public Vector2 balle;
    // Start is called before the first frame update
    //objet statique public Instantiate ( objet original , position Vector3 , rotation du Quaternion );
    public GameObject balle;
    public Transform positionVoiture;
    public Transform positionCannon;
    private Vector3 positionBalle;
    private Quaternion rotationBalle;
    public float nextFire;
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log (Input.GetButton("Fire1"));

        Quaternion quaternionAngles = transform.rotation;
        Vector3 eulerAngles = quaternionAngles.eulerAngles;
        eulerAngles.z = eulerAngles.z - 270;
        //Debug.Log(eulerAngles);
        eulerAngles = ((eulerAngles *(Mathf.PI) )/ 180);
        positionBalle.x = Mathf.Cos(eulerAngles.z)*1.8f +transform.position.x;
        positionBalle.y = Mathf.Sin(eulerAngles.z)*1.8f+ transform.position.y;


        if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
            Instantiate(balle, new Vector3(positionBalle.x, positionBalle.y, 0), Quaternion.identity);
            
        }
        //gameObject.transform.Translate(Direction.normalized * speed * Time.deltaTime);


    }
}
