using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal2 : MonoBehaviour
{
    public DialogueLevel3 DialogueManager;
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
            {"*****899********"
            };
            DialogueManager.SetSentences(dialogue);
            DialogueManager.StartCoroutine(DialogueManager.TypeDialogue());

        }
    }
}
