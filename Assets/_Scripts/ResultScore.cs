using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{

    public Text ScoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager scmn = new ScoreManager();
        ScoreBoard.text = "Your Score: "+ scmn.GetScore();
    }
}
