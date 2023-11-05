using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip[] musicTracks; // 배경음악 트랙 배열
    private int currentTrackIndex = -1; // 현재 트랙 인덱스
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    void Awake()
    {
            audioSource = GetComponent<AudioSource>();
            SelectRandomMusic(); // 무작위 음악 선택
    }

    void SelectRandomMusic()
    {
        if (musicTracks.Length > 0)
        {
            int randomIndex = Random.Range(0, musicTracks.Length);
            // 이전에 선택된 트랙과 다른 트랙이 선택되도록 함
            if (randomIndex == currentTrackIndex)
            {
                randomIndex = (randomIndex + 1) % musicTracks.Length;
            }
            currentTrackIndex = randomIndex;
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play();
            audioSource.loop = true; // 음악 반복 재생
        }
    }

    // 다른 씬으로 이동할 때 이 함수를 호출하여 음악을 유지
    public void PlayMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}