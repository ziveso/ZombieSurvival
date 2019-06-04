using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float BulletForce = 100f;

    //Attached camera
    private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
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
            GameObject temp = Instantiate(Bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody>().velocity = transform.forward * BulletForce;
        }



    }

}
