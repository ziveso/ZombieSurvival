using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int health;
    private float movespeed = 1f;
    private Vector3 movement;
    public Player player;

    private Vector3 findVectorToPlayer()
    {
        Vector3 vector = new Vector3(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
        return vector;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        transform.Rotate(new Vector3(0f, 55, 0f));
        // Debug.Log(findPlayerPosition()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        /**
        Vector3 targetDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        transform.Rotate(new Vector3(0f, - angle, 0f));
        transform.Translate(new Vector3(movespeed, 0f, 0f) * Time.deltaTime);
    */
        float step = movespeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

    }
}
