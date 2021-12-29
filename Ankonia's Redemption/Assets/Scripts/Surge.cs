using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surge : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Move", true);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
       
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Valerie")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((float)-0.9, (float)-2.85);
            anim.SetBool("Move", false);

        }

    }
}
