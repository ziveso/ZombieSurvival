using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int health;
    private float movespeed = 1f;
    private GameObject player;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            float step = movespeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            Vector3 targetDir = (player.transform.position - transform.position);

            float rstep = 10f * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rstep, 1);

            transform.rotation = Quaternion.LookRotation(newDir, Vector3.up);
        }
    }

    private int deadAnimation = 60 * 2;
    private bool isScore = false;
    private void FixedUpdate()
    {
        if (health <= 0)
        {
            if (!isScore)
            {
                player.GetComponent<Player>().AddKillScore();
                isScore = !isScore;
                animator.SetTrigger("Dead");
            }
            deadAnimation--;
            if (deadAnimation <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /**
     * Take damages, it will destory if health less than 0.
     * */
    public bool takeDamage(int dmg)
    {
        health -= dmg;
        return health <= 0;
    }
}
