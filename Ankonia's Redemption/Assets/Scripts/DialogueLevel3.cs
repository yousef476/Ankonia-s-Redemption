using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLevel3 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] sentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject dialogueBox;
    
   


    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        string[] dialogue =
        {" Surge: Memorize the numbers you see on each computer to form the abortion code",
        " Be careful! you have 20 seconds only before the missile launches! "    
            };
       SetSentences(dialogue);
       StartCoroutine(TypeDialogue());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        
        foreach (char letter in sentences[index].ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(2);
        NextSentence();
    }
    public void SetSentences(string[] sentences)
    {
        this.sentences = sentences;
    }
  
    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = " ";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = " ";
            dialogueBox.SetActive(false);
            this.sentences = null;
            index = 0;
           
         
        }
    }
}
