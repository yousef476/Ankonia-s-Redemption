using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public AudioClip shield;
    public GameObject shieldBar;
    public GameObject Valerie;
     float currentTime;
    float startingTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            StartCoroutine(ShieldAppear());
            Destroy(this.gameObject);
            //Valerie.transform.tag = "Player";
            AudioSource.PlayClipAtPoint(shield, transform.position);
            FindObjectOfType<PlayerStats>().CollectShields();
          
        }
            
    }
    public IEnumerator ShieldAppear()
    {
        while (true){
            Valerie.transform.tag = "Shield";
            shieldBar.SetActive(true);
            yield return new WaitForSeconds(5);
            shieldBar.SetActive(false);
    }
    }

}