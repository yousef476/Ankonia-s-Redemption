using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DialogueStart : MonoBehaviour
{
    public DialogueLevel2 DialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            string[] dialogue =
         {"Plague: I see you have the courage to face me",
             " Valerie: Lw el 3arka ebtadet htz3al!"
            };
            DialogueManager.SetSentences(dialogue);
            DialogueManager.StartCoroutine(DialogueManager.TypeDialogue());
        }

    }
}
