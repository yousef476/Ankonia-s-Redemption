using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaugeHealth : MonoBehaviour
{
    public int health = 50;
    public HealthBar healthBar;
    private int currentHealth;
    public AudioClip victory;

    public Animator anim;

	void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
		healthBar.SetHealth(currentHealth);
    }
	public void TakeDamage(int damage)
	{
        anim.SetBool("Hurt", true);

			if (currentHealth > 0)
			{
				currentHealth -= damage;
				healthBar.SetHealth(currentHealth);
				anim.SetBool("Hurt", false);
			}
			else if (currentHealth == 0) {
				Die();
			}
	}

	void Die()
	{
        Debug.Log("Dead");
		anim.SetBool("Dead", true);
		Destroy(gameObject);
        AudioSource.PlayClipAtPoint(victory, transform.position);
        SceneManager.LoadScene("Level3");

    }
}
