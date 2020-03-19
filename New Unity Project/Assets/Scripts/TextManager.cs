using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public Text dialogueText;
    public Animator animator;
    public GameObject player;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetTrigger("FadeIn");
        player.GetComponent<PlayerControler>().LockMouvement = true;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            

        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
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
        foreach (char letter in sentence.ToCharArray())
        {
            GetComponent<AudioSource>().Play();

            dialogueText.text += letter;

            yield return new WaitForSeconds(0.05f);

        }
        yield return new WaitForSeconds(1f);
        DisplayNextSentence();
    }

    void EndDialogue()
    {
        Debug.Log("Fin Dialogue");
        dialogueText.text = "";
        animator.SetTrigger("FadeOut");
        player.GetComponent<PlayerControler>().LockMouvement = false;
    }

}