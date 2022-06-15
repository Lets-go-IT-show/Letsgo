﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    // 첫 번째 노트만 지정
    bool musicStart = false;

    NoteManager theNote;

    Result theResult;

    private void Start()
    {
        theNote = FindObjectOfType<NoteManager>();
        theResult = FindObjectOfType<Result>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            // 닿은 콜라이더가 Note라면 실행
            if (collision.CompareTag("Note"))
            {
                AudioManager.instance.PlayBGM("BGM0");
                musicStart = true;
            }
        }

        // 음악이 끝나면 모든 노트 없애기
      if (AudioManager.instance.bgmPlayer.isPlaying== false)
        {
            theNote.RemoveNote();
            // 결과창 띄우기
            theResult.ShowResult();
            // 끝나는 지점 노래 추가
        } 
    }
}
