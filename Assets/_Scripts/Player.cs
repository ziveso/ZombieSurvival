using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //Movement
    public float MoveSpeed = 10;
    public float TurnRate = 2f;

    //For animation
    Animator animator;
    bool isRunning;

    //Bullet asset
    public GameObject Bullet;
    public float BulletForce = 1f;

    //Attached camera
    private Camera playerCam;

    //Scoring
    private ScoreManager scoremanager;
    public Text ScoreBoard;
    private int SCORE_PER_KILL = 10;

    // Start is called before the first frame update
    void Start()
    {
        scoremanager = new ScoreManager();
        Cursor.lockState = CursorLockMode.Locked;
        playerCam = GetComponentInChildren<Camera>();
        animator = GetComponent<Animator>();
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //FPS Controller movement
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * MoveSpeed * Time.deltaTime, Space.Self);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if( !isRunning )
            {
                isRunning = true;
                animator.SetTrigger("Run");
            }
        }
        else
        {
            if ( isRunning )
            {
                isRunning = false;
                animator.SetTrigger("Idle");
            }
        }

        //Mouse movement
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X") * TurnRate, Input.GetAxisRaw("Mouse Y") * TurnRate);
        transform.Rotate(new Vector3(0f, md.x, 0f));

        playerCam.transform.Rotate(new Vector3(-md.y, 0f, 0f));
        playerCam.transform.rotation.eulerAngles.Set(0f, Mathf.Clamp(transform.rotation.eulerAngles.y, -90f, 90f), 0f);

        //Shooty bits
        if (Input.GetMouseButtonDown(0)) //button 0 is left click and 1 is right click
        {
            Vector3 spanwnBullet = transform.position + (transform.forward * 2);
            spanwnBullet.y += 0.5f;
            GameObject temp = Instantiate(Bullet, spanwnBullet, transform.rotation);
            temp.GetComponent<Rigidbody>().velocity = transform.forward * BulletForce;
        }

    }

    public void AddKillScore()
    {
        scoremanager.AddScore(SCORE_PER_KILL);
        ScoreBoard.text = "Score: " + scoremanager.GetScore();
    }

    public void ResetScore()
    {
        scoremanager.SetScore(0);
        ScoreBoard.text = "Score: " + scoremanager.GetScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit something");
        if (collision.gameObject.tag.Equals("Zombie"))
        {
            Debug.Log("Died");
            SceneManager.LoadScene(2);
        }
    }

}
