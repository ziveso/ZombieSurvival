using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    public float ExplosionRadius = 20f;
    public float ExlposionForce = 600f;
    private Rigidbody rb;

    ParticleSystem emit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ParticleSystem system = GetComponent<ParticleSystem>();
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
            //DetachParticles();
            Destroy(gameObject);
        }
    }

    public void DetachParticles()
    {
        // This splits the particle off so it doesn't get deleted with the parent
        emit.transform.parent = null;
        // this stops the particle from creating more bits
        emit.emissionRate = 0;
    }

}
