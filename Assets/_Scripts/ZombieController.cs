using UnityEngine;
using TMPro;

public class ZombieController : MonoBehaviour
{
    public int health;
    private float movespeed = 2f;
    private GameObject player;
    private TextMeshPro text;
    public int SCORE_PER_KILL = 10;

    Animator animator;

    //Audio sources
    public AudioClip SpawnSound;
    public AudioClip[] DieSounds;
    public AudioClip GoneSound;
    AudioSource audio;
    bool dieSoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        text = GetComponentInChildren<TextMeshPro>();
        SetHPText(health.ToString());
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(SpawnSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            float step = movespeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            Vector3 targetDir = (player.transform.position - transform.position);

            float rstep = 10f * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rstep, 1);

            transform.rotation = Quaternion.LookRotation(newDir, Vector3.up);
            text.SetText(health.ToString());
        }
        else
        {
            text.SetText("");
            if (!dieSoundPlayed)
            {
                int randomed = Random.Range(0, DieSounds.Length - 1);
                audio.PlayOneShot(DieSounds[randomed]);
                dieSoundPlayed = true;
            }
        }
        
    }

    void SetHPText(string text)
    {
        if(text == this.text.text)
        {
            return;
        }
        this.text.SetText(text);
    }

    private int deadAnimation = 60 * 2;
    private bool isScore = false;
    private void FixedUpdate()
    {
        if (health <= 0)
        {
            // should be run at once
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
            if (!isScore)
            {
                // add score
                player.GetComponent<Player>().AddKillScore(SCORE_PER_KILL);

                // animation
                animator.SetTrigger("Dead");
                
                isScore = !isScore;
            }
            deadAnimation--;
            if (deadAnimation == 10)
            {
                audio.PlayOneShot(GoneSound);
            }
                if (deadAnimation <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /**
     * Take damages, it will destory if health less than 0.
     * */
    public bool takeDamage(int dmg)
    {
        health -= dmg;
        return health <= 0;
    }
}
