using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLevel2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] sentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public Rigidbody2D player;


    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        foreach (char letter in sentences[index].ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            continueButton.SetActive(true);
        }
    }
    public void SetSentences(string[] sentences)
    {
        this.sentences = sentences;
    }
  
    public void NextSentence()
    {

        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = " ";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = " ";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.sentences = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
