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
            time += Time.deltaTime;
            // 1초의 1씩 증가
            currentTime += Time.deltaTime;

            // 비트 한 개당 등장 속도
            // 0.5초당 비트 출연
            // Yeah, I'm Tomboy
            if (time < 6d)
            {
                if (currentTime >= 80d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    Debug.Log("Tomboy");
                    GameObjectNote();
                    currentTime -= 80d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }

            // Loot at you, 넌 못 감당해 날
            if (6d <= time && time < 8d)
            {
                if (currentTime >= 50d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 50d / bpm;
                }
            }

            // You took (umm) off hook (yah)
            if (8d <= time && time < 10.5d)
            {
                if (currentTime >= 67d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 67d / bpm;
                }
            }

            // 노트없음
            if (10.5d <= time && time < 11d)
            {
                if (currentTime >= 68d / bpm)
                {
                    currentTime -= 68d / bpm;
                }
            }


            //기분은 Coke like brrr
            if (11d <= time && time < 14d)
            {
                if (currentTime >= 45d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 45d / bpm;
                }
            }

            // 노트없음
            if (14d <= time && time < 16d)
            {
                if (currentTime >= 68d / bpm)
                {
                    currentTime -= 68d / bpm;
                }
            }

            //Look at my toe 나의 Ex 이름 Tattoo
            if (16d <= time && time < 18d)
            {
                if (currentTime >= 60d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 60d / bpm;
                }
            }

            //I got to drink up now 네가 싫다 해도 좋아
            if (18d <= time && time < 23d)
            {
                if (currentTime >= 44d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 44d / bpm;
                }
            }

            // Why are you cranky, boy?
            if (23d <= time && time < 25d)
            {
                if (currentTime >= 40d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 40d / bpm;
                }
            }

            // 노트없음
            if (25d <= time && time < 26d)
            {
                if (currentTime >= 68d / bpm)
                {
                    currentTime -= 68d / bpm;
                }
            }

            // 뭘 그리 찡그려 너
            if (26d <= time && time < 29d)
            {
                if (currentTime >= 37d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 37d / bpm;
                }
            }

            if (29d <= time && time < 30d)
            {
                if (currentTime >= 41d / bpm)
                {
                    currentTime -= 41d / bpm;
                }
            }


            //Do you want a blond barbie doll?
            if (30d <= time && time < 33d)
            {
                if (currentTime >= 41d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 41d / bpm;
                }
            }

            //It's not here, I'm not a doll
            //노트없음
            if (33d <= time && time < 34.5d)
            {
                if (currentTime >= 41d / bpm)
                {
                    currentTime -= 41d / bpm;
                }
            }

            //It's not here, I'm not a doll(like this if you can)
            if (34.5 <= time && time < 38d)
            {
                if (currentTime >= 61d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 61d / bpm;
                }
            }

            //미친년이라 말해, what's the loss to me? Ya
            if (38 <= time && time < 41d)
            {
                if (currentTime >= 73d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 73d / bpm;
                }
            }

            //사정없이 까보라고 you'll lose to me ya
            if (41 <= time && time < 45d)
            {
                if (currentTime >= 76d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 76d / bpm;
                }
            }

            //사랑 그깟 거 따위 내 몸에 상처 하나도 어림없지
            //너의 썩은 내 나는 향수나 뿌릴 바엔
            if (45 <= time && time < 50d)
            {
                if (currentTime >= 33d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 33d / bpm;
                }
            }
            if (50 <= time && time < 52d)
            {
                if (currentTime >= 30d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 30d / bpm;
                }
            }

            //Yeah, I'm fu- tomboy 
            if (52 <= time && time < 54d)
            {
                if (currentTime >= 65d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 65d / bpm;
                }
            }

            //(Uh, ah, uh)
            if (54 <= time && time < 57d)
            {
                if (currentTime >= 35d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 35d / bpm;
                }
            }

            //노트없음
            if (57d <= time && time < 58d)
            {
                if (currentTime >= 41d / bpm)
                {
                    currentTime -= 41d / bpm;
                }
            }

            //Yeah, I'll be the tomboy
            if (58 <= time && time < 61d)
            {
                if (currentTime >= 65d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 65d / bpm;
                }
            }

            //(Uh, ah)
            if (61 <= time && time < 65d)
            {
                if (currentTime >= 35d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 35d / bpm;
                }
            }

            // This is my attitude
            if (65 <= time && time < 68d)
            {
                if (currentTime >= 65d / bpm)
                {

                    GameObjectNote();
                    currentTime -= 65d / bpm;
                }
            }


            //Yeah, I'll be the tomboy
            if (68 <= time && time < 69d)
            {
                if (currentTime >= 70d / bpm)
                {
                    GameObjectNote();
                    currentTime -= 70d / bpm;
                }
            }

            //That's why


            /*
            // 마무리 결과창을 위한 출력
            if (73d < time)
            {
                if (currentTime >= 500d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                {
                    GameObjectNote();
                    currentTime -= 500d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                }
            }*/

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
