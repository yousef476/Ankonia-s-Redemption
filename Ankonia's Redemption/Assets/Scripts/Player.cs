using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour { 
    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public KeyCode slide;
    public KeyCode climb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
  //  [HideInInspector]
    //public AudioClip jump1;
    //public AudioClip jump2;
    // Start is called before the first frame update
    public void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
       // AudioManager.instance.RandomizeSfx(jump1, jump2);
    }
    public void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
   
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        
    }
    
   
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Slide", false);
        anim.SetBool("Hurt", false);
        anim.SetBool("Climb", false);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("grounded", grounded);
        if(Input.GetKeyDown(spacebar) && grounded)
        {
            jump();
        }
        
        if (Input.GetKey(L))
        {
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
            
           
        }
        if (Input.GetKey(R))
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
            
        }
        if (Input.GetKey(slide))
        {
            anim.SetBool("Slide", true);
        }
        if (Input.GetKey(climb))
        {
            anim.SetBool("Climb", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed );
            GetComponent<Rigidbody2D>().gravityScale = 0; 
        }
        else
        {
            anim.SetBool("Climb", false);
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }
   

} 
