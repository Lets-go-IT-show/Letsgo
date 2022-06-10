using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    // 노트의 이미지만 없애고 파괴되지 않도록 설정
    UnityEngine.UI.Image noteImage;

    // 객체가 활성화될 때마다 호출될 함수
    void OnEnable()
    {
        // null 값일 때만 가져오기
        if (noteImage == null)
            noteImage = GetComponent<UnityEngine.UI.Image>();

        noteImage.enabled = true;
        // noteImage.enabled가 false로 된 상태 -> 노트 안보임
        // 노트 활성화시 image도 true로 바꾸기

    }

    // Update is called once per frame
    void Update()
    {
        // 이 스크립트가 붙어있는 객체의 로컬 포지션 값을 오른쪽으로 1초에 noteSpeed만큼 이동시켜주기
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime;
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }

    // 이미지만 비활성화 시키면 Miss연출이 계속해서 뜬다 -> 수정
    public bool GetNoteFlag()
    {
        // enabled이 true이면 이미지가 보여지는 상태 : 이때만 Miss연출
        return noteImage.enabled;
    }
}
