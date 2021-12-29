using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // Start is called before the first frame update
    private float dirX;
    public float guardSpeed;
    private Rigidbody2D rb;
    private bool isFacingRight = false;
    private Vector3 localScale;
    public int guardHealth;
    public int guardDamage;
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    private Animator anim;
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GROUND" )
        {
            anim.SetBool("Stuck", true);

        }
        else if(collision.tag == "Player")
        {
           Attack();
        }
        else if(collision.tag == "Enemy")
        {
            dirX *= -1f;

        }

    }
    private void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Near", false);

        Debug.Log("Distance : " + distance.ToString());
        if (Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            Debug.Log("If: " + Vector2.Distance(transform.position, playerPos.position).ToString());
           // anim.SetBool("Near", true);


            
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, guardSpeed * Time.fixedDeltaTime);
            CheckWhereToFace();
            
        }

        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * guardSpeed, rb.velocity.y);
        CheckWhereToFace();
    }


    private void LateUpdate()
    {
        CheckWhereToFace();
    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
            isFacingRight = true;
        else if (dirX < 0)
            isFacingRight = false;

        if (((isFacingRight) && (localScale.x < 0)) || ((!isFacingRight) && (localScale.x > 0)))
            localScale.x *= -1;


        transform.localScale = localScale;

    }


    void Attack()
    {
        anim.SetBool("Near", true);
        if (guardHealth > 0 && FindObjectOfType<PlayerStats>().health > 0)
        {
            FindObjectOfType<PlayerStats>().TakeDamage(guardDamage);
        }
        else if (guardHealth <= 0 && FindObjectOfType<PlayerStats>().health > 0)
        {
            GuardDie();
        }
        else if (guardHealth > 0 && FindObjectOfType<PlayerStats>().health <= 0)
        {
            FindObjectOfType<PlayerStats>().Die();

        }

    }
    void GuardDie()
    {
        Debug.Log("Guard died");
        anim.SetBool("isDead", true);

    }
}
