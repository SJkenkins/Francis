using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText ;

    public Animator animator;
    public bool bas;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Début de la cinématique");

        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            
            sentences.Enqueue(sentence);
            

        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            GetComponent<AudioSource>().Play();

            dialogueText.text += letter;
            
            yield return new WaitForSeconds(0.05f);
        }
    }

    // Fin du dialogue / de la cinématique --> Changement de scène
    void EndDialogue()
    {
        //Debug.Log("fin");
        // 
        if (bas == true)
        {
            FindObjectOfType<FadeLevel>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            FindObjectOfType<FadeLevel>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
