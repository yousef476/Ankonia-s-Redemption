using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public AudioClip shield;
    public ShieldBar shieldBar;
    public GameObject Valerie;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {   
            shield.SetActive(true);
            for(int i = 0; i < currentTime; i++){
                Valerie.transform.tag = "Shield";
            }
            shield.SetActive(false);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(shield, transform.position);
            FindObjectOfType<PlayerStats>().CollectShields();
           



        }
    }
}