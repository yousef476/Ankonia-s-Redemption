using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaugeHealth : MonoBehaviour
{
    public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	 private Animator anim;

	void Start()
    {
        anim = GetComponent<Animator>();
    }
	public void TakeDamage(int damage)
	{
		//anim.SetBool("Hurt", true);
		if (isInvulnerable)

			return;

		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
        Debug.Log("Dead");
		//anim.SetBool("isDead", true);
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
