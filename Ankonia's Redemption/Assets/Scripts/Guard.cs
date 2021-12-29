using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    public float enemySpeed;
    public bool isFacingRight;
    public int damage;
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < distance)
        {

            //Flip();
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, enemySpeed * Time.deltaTime);
            Attack();
        }
    }
    private void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turn" || collision.tag == "Enemy")
        {
            Flip();
        }
        else if (collision.tag == "Player")
        {
            Attack();
        }

    }
    void Attack()
    {

    }
}
