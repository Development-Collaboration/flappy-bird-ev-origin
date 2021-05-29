
using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody2D))]
public class PlayerCtr : MonoBehaviour
{
    // Behavior

    private float startingGravity;

    private bool godMode = false;

    private bool isContinuable = true;

    [SerializeField]
    private bool playRewardedAd = false;

    //
    [Header("Player Configuration")]
    [Tooltip ("Amount of Vertical Jump")]
    [SerializeField]
    private float upForce;

    [SerializeField] private ParticleSystem dust_PS;


    private bool isDead = false;


    private Rigidbody2D rb2d;
    private Animator anim;
    private CapsuleCollider2D col2d;
    private SpriteRenderer spriteRenderer;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col2d = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        startingGravity = rb2d.gravityScale;

    }

    void Update()
    {

        if(GameManager.instance.gameStatus == GameManager.GameStatus.Play)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;

            rb2d.gravityScale = startingGravity;
        }
        else
        {
            rb2d.bodyType = RigidbodyType2D.Static;
        }

        // 살아 있으면.
        if (!isDead)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                CreateDust();

                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
        {
            if ("Obstacle" == collision.gameObject.tag)
            {

                Physics2D.IgnoreCollision(col2d, GetComponent<Collider2D>());
                //Physics2D.IgnoreCollision(col2d,collision.gameObject.GetComponent<Collider2D>(),true);
            }
        }
        else
        {
            if ("Obstacle" == collision.gameObject.tag || "Ground" == collision.gameObject.tag)
            {

                PlayerDied(collision.gameObject.tag);
            }
        }
    }

    void PlayerDied(string collisionTag)
    {
        print("dead: " + collisionTag);
        //rb2d.velocity = Vector2.zero;

        //rb2d.AddForce(new Vector2(0, -2f));

        // prohibit double point 
        col2d.enabled = false;
        isDead = true;

        //anim.applyRootMotion = false;
        anim.SetTrigger("Die");

        GameManager.instance.PlayerDied(isContinuable);
    }

    void CreateDust()
    {
        dust_PS.Play();
    }

    public void PlayRewardedAd_PlayerResurrection()
    {
        //
        if(playRewardedAd)
        {
            GameManager.instance.OnPlayRewardedAd();
        }

        PlayerResurrection();
    }

    public void PlayerResurrection()
    {
        // center position == starting position
        this.transform.position = new Vector2(0f, 0.5f);        
        isDead = false;    
        anim.SetTrigger("Resurrection");
        col2d.enabled = true;
        godMode = true;

        GameManager.instance.ContinueGame();   

        //
        StartCoroutine("ResurrectionDelay");
    }

    IEnumerator ResurrectionDelay()
    {
        int countTime = 0;

        // 3초
        while (countTime < 12)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            }
            else
                spriteRenderer.color = new Color(1, 1, 1, 0.8f);

            yield return new WaitForSeconds(0.25f);

            countTime++;

            print("countTime: " + countTime);

        }        

        spriteRenderer.color = Color.white;

        godMode = false;
        print("God Mode End");

        isContinuable = false;
        
    }

}
