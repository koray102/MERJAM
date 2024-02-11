using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public int indexDialog;
	public Animator animator;
	public GameObject dialogTrigger;
	private Queue<string> sentences;
	public Text ileri;

	public GameObject cicek;
	public GameObject ilac;
	public GameObject trigger7;
	public Text Gorevler;

	public GameObject Cicek1;
    public GameObject Cicek2;
    public GameObject Eczane;
    public GameObject Durak;
    public GameObject Bank;



    // Use this for initialization
    void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		if(indexDialog == 1 || indexDialog == 2 || indexDialog == 4 || indexDialog == 8)
		{
			nameText.text = "Hakan";
		}
		else
		{
			if(indexDialog == 3)
			{
				if(nameText.text == "B" || nameText.text == "�i�ek�i")
				{
                    nameText.text = "Hakan";
                }
				else if(nameText.text == "Hakan")
				{
                    nameText.text = "�i�ek�i";
                }
			}else if(indexDialog == 5)
			{
                if (nameText.text == "B" || nameText.text == "Eczac� Selin")
				{
                    nameText.text = "Hakan";
                }
                else if (nameText.text == "Hakan")
                {
                    nameText.text = "Eczac� Selin";
                }
            }
			else if(indexDialog == 6) 
			{
                if (nameText.text == "B" || nameText.text == "Otob�s �of�r�")
                {
                    nameText.text = "Hakan";
                }
                else if (nameText.text == "Hakan")
                {
                    nameText.text = "Otob�s �of�r�";
                }
            }
            else if (indexDialog == 7)
            {
                if (nameText.text == "B" || nameText.text == "Di�er Otob�s �of�r�")
                {
                    nameText.text = "Hakan";
                }
                else if (nameText.text == "Hakan")
                {
                    nameText.text = "Di�er Otob�s �of�r�";
                }
            }
            else if (indexDialog == 9)
            {
                if (nameText.text == "Azra")
                {
                    nameText.text = "Hakan";
                }
                else if (nameText.text == "B" || nameText.text == "Hakan")
                {
                    nameText.text = "Azra";
                }
            }
        }
		
			


		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		ileri.text = "";
		dialogTrigger.SetActive(false);
		gameObject.SetActive(false);

		if(indexDialog == 1)
		{
			Gorevler.text = "Di�er �i�ek�iye Git";
			Cicek1.SetActive(false);
		}
		else if(indexDialog == 2)
		{
            Gorevler.text = "Asans�r �le �i�ek�inin Kat�na ��k";
			Cicek2.SetActive(false);
        }
        else if (indexDialog == 3)
        {
			cicek.gameObject.SetActive(true);
            Gorevler.text = "�la�lar�n� almak i�in tepeye git";
			Eczane.SetActive(true);
        }
        else if (indexDialog == 4)
        {
            Gorevler.text = "Yoku�u ��k ve ila�lar�n� al";
        }
        else if (indexDialog == 5)
        {
			ilac.gameObject.SetActive(true);
            Gorevler.text = "Parka gitmek i�in otob�s dura��na git";
            Eczane.SetActive(false);
			Durak.SetActive(true);
        }
        else if (indexDialog == 6)
        {
			trigger7.SetActive(true);
            Gorevler.text = "Sonraki otob�s� bekle";
            Durak.SetActive(false);
        }
        else if (indexDialog == 7)
        {
            Gorevler.text = "Parka git";
			Bank.SetActive(true);
        }
        else if (indexDialog == 8)
        {
            Gorevler.text = "Engelleri a��p parka git";
        }
        else if (indexDialog == 9)
        {
            Gorevler.text = "";
        }
			
	}

}
