using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private Animator anim;
    public AudioClip health;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Taken", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Taken", true);
            Destroy(this.gameObject);
            FindObjectOfType<PlayerStats>().CollectHearts();
            AudioSource.PlayClipAtPoint(health,transform.position);

        }
            
    }
}
