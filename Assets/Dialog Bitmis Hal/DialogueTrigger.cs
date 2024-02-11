using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public int indexDialog;
    public Text ilerle;
    public GameObject Manager;


    private bool dialogBasladi = false;
    public void OnTriggerStay(Collider other)
    {
        Manager.SetActive(true);
        if(other.tag == "Player")
        {               
            if(dialogBasladi == false)
            {
                ilerle.text = "Konuþmak için SPACE bas";
            }

            if(indexDialog == 3 || indexDialog == 5 || indexDialog == 6 || indexDialog == 7)
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
                if (dialogBasladi == false)
                {
                    dialogBasladi = true;
                    TriggerDialogue();
                }
                if(dialogBasladi == true && Input.GetKeyDown(KeyCode.Space))
                {
                    NextSentences();
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
