using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(BoxCollider2D))]

public class StarProjectile : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D bc;


    public float projectileSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        
       

    }

    // Update is called once per frame
    void Update()
    {

        //rb.AddForce(Vector2.right * projectileSpeed);
        transform.position += -transform.right * Time.deltaTime * projectileSpeed;
  
    }



    void OnCollisionEnter2D(Collision2D col) //Was not working because only had a rigid body no box collider
    {

        Destroy(this);


    }



}
