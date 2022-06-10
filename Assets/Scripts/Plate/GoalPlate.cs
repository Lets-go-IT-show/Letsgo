using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlate : MonoBehaviour
{
    AudioSource theAudio;
    NoteManager theNote;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        theNote = FindObjectOfType<NoteManager>();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        // 만약 플레이어가 collider에 닿으면 종료
        if (other.CompareTag("Player"))
        {
            // 끝났을 때 나올 음악
            theAudio.Play();
            // 플레이어가 움직일 수 없도록
            PlayerController.s_canPresskey = false;
            // 노트 생성 막기
            theNote.RemoveNote();
        }
    }*/
}
/*
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Note가 콜라이더에 닿게 되면 파괴 
        if (collision.CompareTag("Note"))
        {
            // 노트가 화면 밖으로 나가면 파괴되는 구간에 숫자 4를 넘기기 -> Miss 연출
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                theEffectManager.JudgementEffect(4);
                theComboManager.ResetCombo();
            }    

            // 해당 노트를 리스트에서 제거
            theTimingManager.boxNoteList.Remove(collision.gameObject);

            // 충돌한 노트 객체를 noteQueue에 Enqueue키워드를 사용하여 반납후
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);

            // 비활성화 상태로 돌리기
            collision.gameObject.SetActive(false);
        }
    }
 
 
 */