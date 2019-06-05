using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private static int scorePoints = 0;

    public int GetScore()
    {
        return scorePoints;
    }

    public void SetScore(int score)
    {
        scorePoints = score;
    }

    public void AddScore(int score)
    {
        scorePoints += score;
    }

}
