using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        anim.SetBool("Walk", true);
        if(this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void OnTrigger2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Attack",true);
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
        if (other.tag == "End-Point")
        {
            flip();
        }
    }

    public void flip(){
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }



}