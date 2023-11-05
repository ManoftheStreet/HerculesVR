using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IdleWeapon : MonoBehaviour
{
    public XRGrabInteractable interactable;
    public GameObject interactionIndicator; // 화살표나 다른 시각적 표시 오브젝트
    private Quaternion defaultRotation;
    private bool isBeingGrabbed = false;

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        defaultRotation = transform.rotation; // 기본 회전값 저장
        // 인터랙션 이벤트에 대한 콜백 함수 등록
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectExit);
    }

    void Update()
    {
        // 인터랙션 상태에 따라 오브젝트의 회전과 표시를 업데이트
        if (!isBeingGrabbed)
        {
            
            interactionIndicator.SetActive(true); // 인터랙션 가능 표시 활성화
        }
        else
        {
            interactionIndicator.SetActive(false); // 인터랙션 가능 표시 비활성화
        }
    }

    // XRGrabInteractable 이벤트에 맞춰 업데이트된 메서드
    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        isBeingGrabbed = true; // 오브젝트가 잡힌 상태로 설정
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        isBeingGrabbed = false; // 오브젝트가 놓여진 상태로 설정
        StartCoroutine(SetRotation());
    }

    IEnumerator SetRotation()
    {
        yield return new WaitForSeconds(3f);
        transform.rotation = defaultRotation;
        transform.position += new Vector3(0, 0.6f, 0);
    }
}