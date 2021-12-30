using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plauge : MonoBehaviour
{
    public Transform player;
    public Dialogue DialogueManager;
    public bool isFlipped = false;

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;
        string[] dialogue =
          {"Plague: I see you have the courage to face me",
             " Valerie: Lw el 3arka ebtadet htz3al!"
            };
        DialogueManager.SetSentences(dialogue);
        DialogueManager.StartCoroutine(DialogueManager.TypeDialogue());

        if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
