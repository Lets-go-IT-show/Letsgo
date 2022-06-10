using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    // 일분당 비트 수 
    // 이 게임에서는 1분의 노트를 120개 생성한다는 의미
    public int bpm = 0;
    // 노트 생성을 위한 시간을 체크할 변수
    // 오차가 적은 double 사용
    double currentTime = 0d;

    // note 생성 막기
    bool noteActive = true;

    // 노트가 생성될 위치 변수
    [SerializeField] Transform tfNoteAppear = null;

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager theComboManager;

    void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theTimingManager = GetComponent<TimingManager>(); // 노트가 생성 되는 순간
    }

    // Update is called once per frame
    void Update()
    {
        if (noteActive)
        {
            // 1초의 1씩 증가
            currentTime += Time.deltaTime;

            // 비트 한 개당 등장 속도
            // 0.5초당 비트 출연
            if (currentTime >= 60d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
            {
                // 공유자원으로 설정된 ObjectPool의 instance를 참조하여 noteQueue에 접근 
                // Dequeue키워드로 queue에 담긴 객체를 빼내온다
                GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

                // 빼내온 Note 객체에 적절한 위치 정보 값을 주고
                t_note.transform.position = tfNoteAppear.position;
                t_note.SetActive(true); // 활성화 상태로 돌리기

                theTimingManager.boxNoteList.Add(t_note); // 해당 리스트를 넣어주기
                currentTime -= 60d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Note가 콜라이더에 닿게 되면 파괴 
        if (collision.CompareTag("Note"))
        {
            // 노트가 화면 밖으로 나가면 파괴되는 구간에 숫자 4를 넘기기 -> Miss 연출
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                theTimingManager.MissRecord();
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

    // 종료되었을 때 노트 없애기
    public void RemoveNote()
    {
        noteActive = false;
        // 출력되어있는노트 없애기
        for (int i = 0; i < theTimingManager.boxNoteList.Count; i++)
        {
            theTimingManager.boxNoteList[i].SetActive(false);
            ObjectPool.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }
    }
}
