using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int currentHealth;
    public int lives;
    public int currentLives;
    private SpriteRenderer spriteRenderer;
    private int heartsCollected = 0;
    private int shieldsCollected = 0;
    private Animator anim;
    public AudioClip hurt;
    public HealthBar healthBar;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentHealth = health;
        healthBar.SetMaxHealth(health);
        currentLives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
      
    }

    public void TakeDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(hurt, transform.position);
        anim.SetBool("Hurt", true);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
            if (currentHealth < 0)
                currentHealth = 0;
        if (this.lives > 0 && currentHealth == 0)
            {
                FindObjectOfType<levelManager>().RespawnPlayer();
                currentHealth = 10;
                this.lives--;
                healthBar.SetHealth(currentHealth);
                healthBar.SetLives(currentLives);
              }
            else if(this.lives <= 0)
            {
                Die();

            }
   
            Debug.Log("Player Health: " + currentHealth.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());

    }


   public void Die()
    {
        Debug.Log("GAME OVER");
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(this.gameObject,2f);
        SceneManager.LoadScene("GameOverScene");

    }
   public void CollectHearts()
    {
        this.heartsCollected += 1;
        if(heartsCollected != 10){
            currentHealth = currentHealth+5;
            healthBar.SetMaxHealth(currentHealth);    
        }
        Debug.Log("Player Hearts: " + this.heartsCollected.ToString());
        Debug.Log("Player Health: " + currentHealth.ToString());


    }
    public void CollectShields()
    {

        if (shieldsCollected != 10)
        {
            
            this.shieldsCollected += 1;
        }

    }
}
