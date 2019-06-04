using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int health;
    private float movespeed = 1f;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = movespeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        Vector3 targetDir = (player.transform.position - transform.position);

        float rstep = 10f * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rstep,1);

        transform.rotation = Quaternion.LookRotation(newDir, Vector3.up);
    }
}
