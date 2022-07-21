using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("CORRECT SPAWN");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * projectileSpeed;
    
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this);
    }

} 
