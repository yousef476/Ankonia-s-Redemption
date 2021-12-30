using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaugeWeapon : MonoBehaviour
{
    public int attackDamage = 5;
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		//Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		//if (colInfo != null)
		//{
			//colInfo.GetComponent<PlayerStats>().TakeDamage(attackDamage);
		//}
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
