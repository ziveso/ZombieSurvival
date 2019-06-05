using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    public GameObject boss;
    Collider m_Collider;
    Vector3 m_Size;
    public int spawntime = 5;
    int countdown;

    int spawnFarRadius = 5;

    void Start()
    {
        countdown = spawntime * 60;
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size * 9 / 10;
    }

    private bool isBossSpawn = false;
    private void FixedUpdate()
    {
        if (ScoreManager.GetScore() == 100)
        {
            if (!isBossSpawn)
            {
                Instantiate(boss, new Vector3(0, 0, 0), Quaternion.identity);
                isBossSpawn = true;
            }
        }
        // let spawn it randomly on the map
        if (countdown == 0)
        {
            Vector3 playerPosition = player.GetComponent<Player>().transform.position;
            // first random x axis
            float x;
            float z;
            do
            {
                float x_size = m_Size.x / 2;
                x = Random.Range(-x_size, x_size);
                float z_size = m_Size.z / 2;
                z = Random.Range(-z_size, x_size);
            } while ((Mathf.Abs(playerPosition.x - x) <= 10) && (Mathf.Abs(playerPosition.z - z) <= 10));

            Instantiate(zombie, new Vector3(x, 0, z), Quaternion.identity);

            countdown = spawntime * 60;
        }
        else
        {
            countdown--;
        }
    }
}
