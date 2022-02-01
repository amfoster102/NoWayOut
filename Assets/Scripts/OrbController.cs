using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public Vector3 velocity;
    
   
    Rigidbody2D rb;
    Vector3 initForce;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Vector3 forceDirection = new Vector3(Random.Range(-1f, -.5f), Random.Range(-1f, -.5f), 0);
        forceDirection.Normalize();

        float forcePower = 1;
        initForce = forcePower * forceDirection;
        rb.AddForce(initForce, ForceMode2D.Impulse);

       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myVelocity = rb.velocity;
        myVelocity.Normalize();
        float forcePower = 0.5f;
        rb.AddForce(forcePower * myVelocity);
    }

    
}
