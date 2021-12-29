using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValerieIntro : MonoBehaviour
{
    public Dialogue DialogueManager;
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
        if(other.tag == "Surge")
        {
            string[] dialogue =
            {"Surge: Valerie! I just heard that Pyro the ruler will launch missiles towards planet Earth ",
             "This will kill billions of innocent people!",
             "Valerie: Pyro has been a tyrant for years and we should not tolerate his injustice anymore!",
             "WE SHOULD STOP HIM!",
             "Surge: The missiles are in the Pyro's fortress in the headquarters",
             "I'll help you sneak in and abort the missiles",
             "But be careful! you'll face many challenges and dangers",
             "Valerie: I'm READY!"

            };
            DialogueManager.SetSentences(dialogue);
            DialogueManager.StartCoroutine(DialogueManager.TypeDialogue());

        }
    }
}
