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
        ScoreBoard.text = "Your Score: "+ ScoreManager.GetScore();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
