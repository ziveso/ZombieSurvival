using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;

    // 0 is not spawn
    // 1 is to be spawn
    // 2 is spawned
    // 3 is killed
    private int bossState = 0;

    public int ScoreToSpawn = 100;
    public int TimeBeforeSpawn = 10;

    private void SpawnBoss(int x, int y, int z)
    {
        Instantiate(boss, new Vector3(x, y, z), Quaternion.identity);
    }

    private void FixedUpdate()
    {
        switch (bossState)
        {
            case 0: NotSpawn(); break;
            case 1: ToBeSpawn(); break;
            case 2: Spawned(); break;
            case 3: Killed(); break;
            default: break;
        }
    }

    private void NotSpawn()
    {
        int currentScore = ScoreManager.GetScore();
        if (currentScore > 0 && currentScore % ScoreToSpawn == 0)
        {
            CounterSpawn.SetCounter(TimeBeforeSpawn);
            bossState = 1;
        }
    }

    private void ToBeSpawn()
    {
        if (CounterSpawn.GetCounter() == 0)
        {
            Debug.Log("spanwned");
            SpawnBoss(0, 0, 0);
            bossState = 2;
        }
    }

    private void Spawned()
    {
        if (GameObject.Find("Boss(Clone)") == null)
        {
            bossState = 3;
        }
    }

    private void Killed()
    {
        bossState = 0;
    }
}
