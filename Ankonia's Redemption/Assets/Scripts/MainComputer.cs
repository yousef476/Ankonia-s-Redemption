using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainComputer : MonoBehaviour
{
    public DialogueLevel3 DialogueManager;
    public GameObject inputfield;
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
            inputfield.SetActive(true);
            string[] dialogue =
            {"Enter the code"
            };
            DialogueManager.SetSentences(dialogue);
            DialogueManager.StartCoroutine(DialogueManager.TypeDialogue());


        }
    }
}
