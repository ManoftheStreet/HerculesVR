using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public PlayerHealth playerHealth; // PlayerHealth 스크립트에 대한 참조

    // 다른 Collider가 이 오브젝트의 Trigger에 들어오면 호출됩니다.
    private void OnTriggerEnter(Collider other)
    {
        // 'other'가 플레이어인지 확인합니다.
        if (other.CompareTag("Player"))
        {
            // 게임 클리어 로직을 여기에 작성합니다.
            // 예를 들어, 랭크를 결정하고 저장하는 코드 등이 될 수 있습니다.
            float playerHealthPoints = playerHealth.health; // 플레이어의 현재 체력을 가져옵니다.
            string rank = DetermineRank(playerHealthPoints); // 랭크를 결정하는 함수를 호출합니다.

            // 랭크를 텍스트로 출력하는 로직은 별도로 구현하시면 됩니다.
            // 예: someUITextElement.text = "Your rank: " + rank;
            Debug.Log("Your rank: " + rank); // 콘솔에 랭크를 출력합니다.
        }
    }

    // 플레이어의 체력 점수에 따라 랭크를 결정하는 메소드입니다.
    private string DetermineRank(float health)
    {
        if (health >= 100) return "SSS";
        if (health >= 90) return "SS";
        if (health >= 80) return "S";
        // 10점 단위로 계속 내려갑니다.
        if (health >= 70) return "A";
        if (health >= 60) return "B";
        if (health >= 50) return "C";
        // 50점 미만은 무조건 D 랭크입니다.
        return "D";
    }
}