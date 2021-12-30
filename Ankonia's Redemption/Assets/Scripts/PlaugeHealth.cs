using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaugeHealth : MonoBehaviour
{
    public int health = 50;
    public HealthBar healthBar;
    public int currentHealth;

    public GameObject deathEffect;

	//public bool isInvulnerable = false;

	 private Animator anim;

	void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
    }
	public void TakeDamage(int damage)
	{
        anim.SetBool("Hurt", true);
        //if (isInvulnerable)
			//return;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
        Debug.Log("Dead");
		anim.SetBool("Dead", true);
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
