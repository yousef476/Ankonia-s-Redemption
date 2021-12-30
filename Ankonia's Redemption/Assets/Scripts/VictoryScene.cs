using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public AudioClip victory;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator wait()
    {
        AudioSource.PlayClipAtPoint(victory, transform.position);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartMenu");

    }
}
