using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;
    public GameObject ExitBtn;
    bool isTyping = false;

    AudioSource audio;
    // Start is called before the first frame update

    void OnEnable()
    {
        string sampleText = dialogText.text;
        dialogText.text = "";
        StartCoroutine(Typing(sampleText));
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update() 
    {
        if (isTyping)
        {
            ExitBtn.SetActive(false);
        }
        else
        {
            ExitBtn.SetActive(true);
        }
    }

    IEnumerator Typing(string text)
    {
        isTyping = true;
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            if (audio != null && audio.clip != null)
            {
                audio.PlayOneShot(audio.clip);
            }
            yield return new WaitForSeconds(0.05f);
        }
        isTyping=false;
    }
}