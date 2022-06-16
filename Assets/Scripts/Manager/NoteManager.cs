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
    double time = 0d;

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
            // 시간 계산
            time += Time.deltaTime;
            // 1초의 1씩 증가
            currentTime += Time.deltaTime;

            // 비트 한 개당 등장 속도
            // 0.5초당 비트 출연
            if (time <= 8d)
            {
                if (currentTime >= 89d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 89d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }
            if (8d < time && time < 15d)
            {
                if (currentTime >= 88d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 88d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            // 많은 비트 시작
            if (15d <= time && time < 16d)
            {
                if (currentTime >= 40d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 40d / bpm;
                }
            }

            if (16d <= time && time < 21d)
            {
                if (currentTime >= 47d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 47d / bpm;
                }
            }

            if (21d <= time && time <= 22d)
            {
                if (currentTime >= 60d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 60d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }


            if (21d < time && time < 30d)
            {
                if (currentTime >= 55d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 55d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (21d < time && time < 30d)
            {
                if (currentTime >= 63d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 63d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (30d < time && time < 36d)
            {
                if (currentTime >= 45d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 45d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (36d < time && time < 39d)
            {
                if (currentTime >= 30d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 30d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (39d < time && time < 46d)
            {
                if (currentTime >= 50d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 50d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }
            if (46d < time && time < 54d)
            {
                if (currentTime >= 40d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 40d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (54d < time && time < 55d)
            {
                if (currentTime >= 38d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 38d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (55d < time && time < 55.5d)
            {
                if (currentTime >= 40d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 40d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (55.5d < time && time < 56.5d)
            {
                if (currentTime >= 38d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 38d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }
            if (55.5d < time && time < 56d)
            {
                if (currentTime >= 40d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 40d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (56d < time && time < 60d)
            {
                if (currentTime >= 35d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 35d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (60d < time && time < 68d)
            {
                if (currentTime >= 50d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 50d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (60d < time && time < 66d)
            {
                if (currentTime >= 55d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 55d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (66d < time && time < 73d)
            {
                if (currentTime >= 60 / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 60d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            if (73d < time)
            {
                if (currentTime >= 500d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 500d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

        }
    }

    public void GameObjectNote()
    {
        // 공유자원으로 설정된 ObjectPool의 instance를 참조하여 noteQueue에 접근 
        // Dequeue키워드로 queue에 담긴 객체를 빼내온다
        GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();

        // 빼내온 Note 객체에 적절한 위치 정보 값을 주고
        t_note.transform.position = tfNoteAppear.position;
        t_note.SetActive(true); // 활성화 상태로 돌리기

        theTimingManager.boxNoteList.Add(t_note); // 해당 리스트를 넣어주기
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
