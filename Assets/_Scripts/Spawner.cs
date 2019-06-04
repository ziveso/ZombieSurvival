using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    Collider m_Collider;
    Vector3 m_Size;
    public int spawntime = 5;
    int countdown;

    void Start()
    {
        countdown = spawntime * 60;
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size * 9 / 10;

        Instantiate(zombie, new Vector3(-45, 1, -45), Quaternion.identity);
        Instantiate(zombie, new Vector3(45, 1, 45), Quaternion.identity);
        Instantiate(zombie, new Vector3(45, 1, -45), Quaternion.identity);
        Instantiate(zombie, new Vector3(-45, 1, 45), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // let spawn it randomly on the map

        if (countdown == 0)
        {
            // first random x axis
            float x_size = m_Size.x / 2;
            float x = Random.Range(-x_size, x_size);

            // random z axis
            float z_size = m_Size.z / 2;
            float z = Random.Range(-z_size, x_size);


            Instantiate(zombie, new Vector3(x, 1, z), Quaternion.identity);

            countdown = spawntime * 60;
        }
        else
        {
            countdown--;
        }
    }
}
