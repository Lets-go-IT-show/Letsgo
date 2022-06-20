﻿using System.Collections;
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
        
        switch (MusicChoice.musicIndex)
        {
            case 0:
                {
                    if (noteActive)
                    {
                        time += Time.deltaTime;
                        // 1초의 1씩 증가
                        currentTime += Time.deltaTime;

                        // 비트 한 개당 등장 속도
                        // 0.5초당 비트 출연
                        if (time < 3d)
                        {
                            if (currentTime >= 60d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                            {
                                GameObjectNote();
                                currentTime -= 60d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                            }
                        }
                        if (3d <= time && time <= 4d)
                        {
                            if (currentTime >= 61d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 61d / bpm;
                            }
                        }

                        if (4d < time && time < 6d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }

                        // 종성이 파트 시작
                        if (6d <= time && time < 13d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }

                        if (13d <= time && time < 13.05d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                currentTime -= 40d / bpm;
                            }
                        }

                        // 성훈이 파트
                        if (13.05d <= time && time < 17d)
                        {
                            if (currentTime >= 30d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 30d / bpm;
                            }
                        }


                        if (17d <= time && time < 18d)
                        {
                            if (currentTime >= 32d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 32d / bpm;
                            }
                        }
                        // 노트 없음
                        if (18d <= time && time < 19d)
                        {
                            if (currentTime >= 55d / bpm)
                            {
                                currentTime -= 55d / bpm;
                            }
                        }

                        // 니키 파트
                        if (19d <= time && time < 22d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }

                        if (22d <= time && time < 23d)
                        {
                            if (currentTime >= 65d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 65d / bpm;
                            }
                        }
                        if (23d <= time && time < 25d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }

                        // 정원 선우 파트
                        if (25d <= time && time < 25.5d)
                        {
                            if (currentTime >= 38d / bpm)
                            {
                                currentTime -= 38d / bpm;
                            }
                        }

                        if (25.5d <= time && time < 27.8d)
                        {
                            if (currentTime >= 48d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 48d / bpm;
                            }
                        }
                        // 일단 뛰어
                        if (27.8d <= time && time < 28.4d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                currentTime -= 57d / bpm;
                            }
                        }
                        if (28.4d <= time && time < 31d)
                        {
                            if (currentTime >= 48d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 48d / bpm;
                            }
                        }

                        // 제이크 불꽃에
                        if (30.5d <= time && time < 31.2d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }

                        if (31.2d <= time && time < 34d)
                        {
                            if (currentTime >= 59d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 59d / bpm;
                            }
                        }
                        // 종성 파트 정답을
                        if (34d <= time && time < 34.2d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (34.2d <= time && time < 36.55d)
                        {
                            if (currentTime >= 60d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 60d / bpm;
                            }
                        }
                        // 이희승 뜨거운 심장
                        if (36.55d <= time && time < 37.8d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (37.8d <= time && time < 40d)
                        {
                            if (currentTime >= 32d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 32d / bpm;
                            }
                        }

                        if (40d <= time && time < 44d)
                        {
                            if (currentTime >= 32d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 31d / bpm;
                            }
                        }

                        // 섬머!
                        if (44d <= time && time < 44.5d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (44.5d <= time && time < 46.8d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 57d / bpm;
                            }
                        }
                        // 일단 뛰어
                        if (46.8d <= time && time < 47.47d)
                        {
                            if (currentTime >= 48d / bpm)
                            {
                                currentTime -= 48d / bpm;
                            }
                        }

                        if (47.47d <= time && time < 49d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 57d / bpm;
                            }
                        }
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
                } break;
            case 1:
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

                        if (29d <= time && time < 31d)
                        {
                            if (currentTime >= 41d / bpm)
                            {
                                currentTime -= 41d / bpm;
                            }
                        }


                        //Do you want a blond barbie doll?
                        if (31d <= time && time < 33d)
                        {
                            if (currentTime >= 41d / bpm)
                            {
                                currentTime -= 41d / bpm;
                            }
                        }

                        

                    }

                }
                break;
            case 2:
                {
                    if (noteActive)
                    {
                        time += Time.deltaTime;
                        // 1초의 1씩 증가
                        currentTime += Time.deltaTime;

                        if (time < 0.75d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (0.75d <= time && time < 1.8d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40d / bpm;
                            }
                        }
                        // 폼에 살고 죽고
                        if (1.8d <= time && time < 1.915d)
                        {
                            if (currentTime >= 36d / bpm)
                            {
                                currentTime -= 36d / bpm;
                            }
                        }

                        if (1.915d <= time && time < 4d)
                        {
                            if (currentTime >= 39.5d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 39.5d / bpm;
                            }
                        }
                        // 폼 때문에 살고
                        if (4d <= time && time < 7d)
                        {
                            if (currentTime >= 39.5d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 39.5d / bpm;
                            }
                        }

                        // 폼 하나에 죽고 살고
                        if (7d <= time && time < 9d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (9d <= time && time < 13d)
                        {
                            if (currentTime >= 40.5d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40.5d / bpm;
                            }
                        }
                        // 폼생폼사야 
                        if (13d <= time && time < 16d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }

                        // 사나이 가는 길은
                        if (16d <= time && time < 25d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }
                        // 없을꺼야
                        if (25d <= time && time < 26.5d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (26.5d <= time && time < 26.8d)
                        {
                            if (currentTime >= 55d / bpm)
                            {
                                currentTime -= 55d / bpm;
                            }
                        }
                        // 같아도 까지            
                        if (26.8d <= time && time < 34d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }

                        if (34d <= time && time < 37.5d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40d / bpm;
                            }
                        }
                        // 보내줬지?
                        if (37.5d <= time && time < 38.3d)
                        {
                            if (currentTime >= 40.5d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40.5d / bpm;
                            }
                        }


                        if (38.3d <= time && time < 38.53d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        // 보내줬찌
                        if (38.53d <= time && time < 41d)
                        {
                            if (currentTime >= 77d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 77d / bpm;
                            }
                        }

                        if (41d <= time && time < 42d)
                        {
                            if (currentTime >= 77d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 77d / bpm;
                            }
                        }

                        // 은지원
                        if (42d <= time && time < 43.5d)
                        {
                            if (currentTime >= 39d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 39d / bpm;
                            }
                        }

                        if (43.5d <= time && time < 46d)
                        {
                            if (currentTime >= 41d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 41d / bpm;
                            }
                        }

                        if (46d <= time && time < 48d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 40d / bpm;
                            }
                        }

                        // ---- 두마디
                        if (48d <= time && time < 51.5d)
                        {
                            if (currentTime >= 79d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 79d / bpm;
                            }
                        }

                        if (51.5d <= time && time < 54.7d)
                        {
                            if (currentTime >= 79d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 79d / bpm;
                            }
                        }

                        // 그저 안녕이란
                        if (54.7d <= time && time < 57.7d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }

                        if (57.7d <= time && time < 57.9d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        // 눈물을 삼키며
                        if (57.9d <= time && time < 60.5d)
                        {
                            if (currentTime >= 39d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 39d / bpm;
                            }
                        }

                        if (60.5d <= time && time < 60.7d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        // 돌아섰ㄷ
                        if (60.7d <= time && time < 63.8d)
                        {
                            if (currentTime >= 79d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 79d / bpm;
                            }
                        }

                        if (63.8d <= time && time < 64d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }

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
                } break;
            default:break;
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
