using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public Text dialogText;

    int clickCount = 0;
    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject ExitBtn;
    public GameObject ChangeSceneBtn;

    AudioSource audio;
    bool isTyping = false;
    string[] sentences = {
        "어서 오게! 나는 올림포스의 12신 중 하나이자 신들의 왕인 제우스라고 하네",
        "스텔라 미쓰에 온 것을 환영한다네!",
        "응? 스텔라 미쓰가 뭐 하는 곳이냐구? 좋아 그럼 설명해주지",
        "스텔라 미쓰는 밤하늘에 떠 있는 별과 별자리를 구현해놓은 가상 플라네타리움이라고 해",
        "가짜 별이긴 하지만 실제 별의 위치를 가져왔기 때문에 원하는 별자리들을 찾아볼 수 있다네",
        "또한 별자리에 담긴 신화 이야기도 볼 수 있고 심지어는 한국에서 볼 수 없는 별자리까지 찾아볼 수 있지",
        "그럼 어떻게 볼 수 있냐구?",
        "보고싶으면 날 따라와보게!"
    };

    void OnEnable()
    {
        ExitBtn.SetActive(false);
        ChangeSceneBtn.SetActive(false);
        ShowCurrentSentence();
        StartCoroutine(Typing(sentences[clickCount])); // 첫 번째 문장에 대한 코루틴 시작
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isTyping)
        {
            // 문장이 아직 타이핑 중일 때 "Next" 버튼와 "Prev" 버튼 비활성화
            nextBtn.SetActive(false);
            prevBtn.SetActive(false);
        }
        else
        {
            // 문장이 타이핑이 끝났을 때 "Next" 버튼와 "Prev" 버튼 활성화
            nextBtn.SetActive(true);

            if (clickCount > 0)
            {
                prevBtn.SetActive(true);
            }
            else
            {
                prevBtn.SetActive(false);
            }
            if(clickCount > 6)
            {
                nextBtn.SetActive(false);
                ChangeSceneBtn.SetActive(true);
            }
        }
    }

    public void NextBtn()
    {
        if (clickCount < sentences.Length - 1 && !isTyping)
        {
            clickCount++;
            ShowCurrentSentence();
            StartCoroutine(Typing(sentences[clickCount]));
        }
    }

    public void PrevBtn()
    {
        if (clickCount > 0 && !isTyping)
        {
            clickCount--;
            ShowCurrentSentence();
            StartCoroutine(Typing(sentences[clickCount]));
        }
    }

    void ShowCurrentSentence()
    {
        dialogText.text = sentences[clickCount];
    }

    IEnumerator Typing(string text)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            if (audio != null && audio.clip != null)
            {
                audio.PlayOneShot(audio.clip);
            }
            yield return new WaitForSeconds(0.01f);
        }
        isTyping = false;
    }
}