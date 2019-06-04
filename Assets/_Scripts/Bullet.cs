using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    public float ExplosionRadius = 20f;
    public float ExlposionForce = 600f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("Ground"))
        { 
            if(collision.gameObject.tag.Equals("Zombie"))
            {
                ZombieController zombie = collision.gameObject.GetComponent<ZombieController>() as ZombieController;
                zombie.takeDamage(50);
            }
            Destroy(gameObject);
        }
    }

}
