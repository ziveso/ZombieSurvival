using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int health;
    private float movespeed = 1f;
    private Vector3 movement;

    private float[] findPlayerPosition()
    {
        float[] position = new float[3];
        position[0] = 1f;
        position[1] = 1f;
        position[2] = 1f;
        
        return position;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        Debug.Log(findPlayerPosition()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movespeed, 0f, 0f) * Time.deltaTime);
    }
}
