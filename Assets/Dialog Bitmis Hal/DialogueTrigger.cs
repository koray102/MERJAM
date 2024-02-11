using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public int indexDialog;
    public Text ilerle;
    public GameObject Manager;
	public Movement movementSc;
    public DialogueManager dialogueManager;


    private bool dialogBasladi = false;
    public void OnTriggerStay(Collider other)
    {
        Manager.SetActive(true);
        if(other.tag == "Player")
        {               
            if(dialogBasladi == false)
            {
                ilerle.text = "Konuşmak için SPACE bas";
            }

            if(indexDialog == 3 || indexDialog == 5)
            {              
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(dialogBasladi == false)
                    {
                        dialogBasladi = true;
                        TriggerDialogue();
                    }
                    else if(dialogBasladi == true)
                    {
                        NextSentences();
                    }
                }
            }
            else if(indexDialog == 1 || indexDialog == 2 || indexDialog == 4 || indexDialog == 8 || indexDialog == 9) 
            {
                if (dialogBasladi == false && Input.GetKeyDown(KeyCode.Space))
                {
                    dialogBasladi = true;
                    TriggerDialogue();
                }
                else if(dialogBasladi == true && Input.GetKeyDown(KeyCode.Space))
                {
                    NextSentences();
                }
            }else if(indexDialog == 6 && movementSc.otobusSayi == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(dialogBasladi == false)
                    {
                        dialogBasladi = true;
                        TriggerDialogue();
                    }
                    else if(dialogBasladi == true)
                    {
                        NextSentences();
                    }
                }
            }else if (indexDialog == 7 && movementSc.otobusSayi == 2)
            {
               if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(dialogBasladi == false)
                    {
                        dialogBasladi = true;
                        TriggerDialogue();
                    }
                    else if(dialogBasladi == true)
                    {
                        NextSentences();
                    }
                } 
            }



        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ilerle.text = "";
        }
    }

    public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

    public void NextSentences()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
