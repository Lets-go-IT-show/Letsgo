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
                        if (6d <= time && time < 12.8d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }

                        /*if (12.8d <= time && time < 12.9d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                currentTime -= 40d / bpm;
                            }
                        }*/

                        // 성훈이 파트
                        if (12.8d <= time && time < 17d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }


                        if (17d <= time && time < 18d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }
                        // 노트 없음
                        /*if (18d <= time && time < 19.3d)
                        {
                            if (currentTime >= 55d / bpm)
                            {
                                currentTime -= 55d / bpm;
                            }
                        }*/

                        // 니키 파트
                        if (18d <= time && time < 22d)
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
                        if (25d <= time && time < 25.8d)
                        {
                            if (currentTime >= 60d / bpm)
                            {
                                currentTime -= 60d / bpm;
                            }
                        }

                        if (25.9d <= time && time < 27.8d)
                        {
                            if (currentTime >= 60d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 60d / bpm;
                            }
                        }
                        // 일단 뛰어
                        if (27.8d <= time && time < 28.5d)
                        {
                            if (currentTime >= 60d / bpm)
                            {
                                currentTime -= 60d / bpm;
                            }
                        }
                        if (28.6d <= time && time < 31.5d)
                        {
                            if (currentTime >= 60d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 60d / bpm;
                            }
                        }

                        // 제이크 불꽃에
                        /*if (31.6d <= time && time < 31.2d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }*/

                        if (31.6d <= time && time < 34d)
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
                            if (currentTime >= 32d / bpm)
                            {
                                currentTime -= 32d / bpm;
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
                            if (currentTime >= 34d / bpm)
                            {
                                currentTime -= 34d / bpm;
                            }
                        }

                        if (37.8d <= time && time < 40d)
                        {
                            if (currentTime >= 34d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 34d / bpm;
                            }
                        }

                        if (40d <= time && time < 44d)
                        {
                            if (currentTime >= 34d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 34d / bpm;
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
                        if (46.8d <= time && time < 47.4d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                currentTime -= 57d / bpm;
                            }
                        }

                        if (47.4d <= time && time < 49.8d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 57d / bpm;
                            }
                        }


                        if (49.8d <= time && time < 50.1d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }

                        // 나의 나침반
                        if (50.2d <= time && time < 56.6d)
                        {
                            if (currentTime >= 34d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 34d / bpm;
                            }
                        }

                        // 섬머!
                        if (56.6 <= time && time < 57d)
                        {
                            if (currentTime >= 40d / bpm)
                            {
                                currentTime -= 40d / bpm;
                            }
                        }

                        if (57d <= time && time < 59d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 57d / bpm;
                            }
                        }
                        // 일단 뛰어
                        if (59d <= time && time < 59.5d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                currentTime -= 57d / bpm;
                            }
                        }

                        if (59.5d <= time && time < 62.4d)
                        {
                            if (currentTime >= 57d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 57d / bpm;
                            }
                        }

                        // 우우우우우우우우우
                        if (62.4d <= time && time < 68d)
                        {
                            if (currentTime >= 38d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 38d / bpm;
                            }
                        }

                        // 정답이 아니라해도
                        if (68d <= time && time < 69.2d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 50d / bpm;
                            }
                        }

                        // 우우우우우우우
                        if (69.2d <= time && time < 70.5d)
                        {
                            if (currentTime >= 38d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 38d / bpm;
                            }
                        }

                        // 정답이 아니라해도
                        if (70.5d <= time && time < 71.5d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 50d / bpm;
                            }
                        }

                        // 우우우우우우우
                        if (71.5d <= time && time < 72.8d)
                        {
                            if (currentTime >= 38d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 38d / bpm;
                            }
                        }

                        if (72.8d <= time && time < 75d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 50d / bpm;
                            }
                        }

                        if (75d <= time && time < 75.8d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 50d / bpm;
                            }
                        }


                        // 마무리 결과창을 위한 출력
                        if (76d < time)
                        {
                            if (currentTime >= 500d / bpm) // 60이라는 숫자의 크기가 작을 수록 노트 생성되는 간격이 줄어들면서 노트들이 많이 생성된다, 현재 게임에서 bpm이 80으로 설정되어 있음, 
                            {
                                GameObjectNote();
                                currentTime -= 500d / bpm; // currentTime = 0 안됨, 소수점 오차발생/시간적 손실 발생
                            }
                        }

                    }
                }
                break;

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
                        if (5.8d <= time && time < 6d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 50d / bpm;
                            }
                        }

                        // You took (umm) off hook (yah)
                        if (6d <= time && time < 10.5d)
                        {
                            if (currentTime >= 60d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 60d / bpm;
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
                        if (11d <= time && time < 16d)
                        {
                            if (currentTime >= 45d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 45d / bpm;
                            }
                        }

                        // 노트없음
                        /*if (14d <= time && time < 16d)
                        {
                            if (currentTime >= 68d / bpm)
                            {
                                currentTime -= 68d / bpm;
                            }
                        }*/

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
                        if (18d <= time && time < 22.8d)
                        {
                            if (currentTime >= 37d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 37d / bpm;
                            }
                        }

                        // Why are you cranky, boy?
                        if (22.8d <= time && time < 25d)
                        {
                            if (currentTime >= 37d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 37d / bpm;
                            }
                        }

                        // 노트없음
                        if (25d <= time && time < 25.8d)
                        {
                            if (currentTime >= 68d / bpm)
                            {
                                currentTime -= 68d / bpm;
                            }
                        }

                        // 뭘 그리 찡그려 너
                        if (25.8d <= time && time < 29d)
                        {
                            if (currentTime >= 37d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 37d / bpm;
                            }
                        }

                        if (29d <= time && time < 29.5d)
                        {
                            if (currentTime >= 41d / bpm)
                            {
                                currentTime -= 41d / bpm;
                            }
                        }


                        //Do you want a blond barbie doll?
                        if (29.5d <= time && time < 33d)
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

                        // 마무리 결과창을 위한 출력
                        if (70d < time)
                        {
                            if (currentTime >= 500d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 500d / bpm;
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
                            if (currentTime >= 42d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 42d / bpm;
                            }
                        }
                        // 나 폼에 살고 죽고 폼 때문에 살고
                        if (1.8d <= time && time < 2.2d) //if (1.8d <= time && time < 1.915d)
                        {
                            if (currentTime >= 36d / bpm)
                            {
                                currentTime -= 36d / bpm;
                            }
                        }

                        if (2.2d <= time && time < 7d)
                        {
                            if (currentTime >= 67.7d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 67.7d / bpm;
                            }
                        }

                        if (6d <= time && time < 7.6d)
                        {
                            if (currentTime >= 39.5d / bpm)
                            {
                                currentTime -= 39.5d / bpm;
                            }
                        }

                        // 폼 하나에 죽고 살고
                        if (7.6d <= time && time < 8d)
                        {
                            if (currentTime >= 30d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 30d / bpm;
                            }
                        }

                        //사나이가 가는 오 그 길에 길에
                        if (8d <= time && time < 9d)
                        {
                            if (currentTime >= 40.5d / bpm)
                            {
                                currentTime -= 40.5d / bpm;
                            }
                        }
                        if (9d <= time && time < 14d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }


                        // 폼생폼사야 

                        if (14d <= time && time < 16d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
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

                        if (51.5d <= time && time < 54.6d)
                        {
                            if (currentTime >= 79d / bpm)
                            {
                                currentTime -= 79d / bpm;
                            }
                        }

                        // 그저 안녕이란
                        if (54.6d <= time && time < 57.7d)
                        {
                            if (currentTime >= 79d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 79d / bpm;
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

                        if (60.5d <= time && time < 60.9d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        // 돌아섰ㄷ
                        if (60.9d <= time && time < 63.8d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }

                        if (63.8d <= time && time < 66.5d)
                        {
                            if (currentTime >= 81d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 81d / bpm;
                            }
                        }

                        if (66.5d <= time && time < 66.52d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }

                        if (66.52d <= time && time < 67.5d)
                        {
                            if (currentTime >= 43d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 43d / bpm;
                            }
                        }

                        // 폼에 살고
                        if (67.5d <= time && time < 69.3d)
                        {
                            if (currentTime >= 38d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 38d / bpm;
                            }
                        }
                        if (69.3d <= time && time < 72d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        if (72d <= time && time < 73.5d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }

                        // 이제와 구차하게
                        if (73.5d <= time && time < 74.0d)
                        {
                            if (currentTime >= 80d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 80d / bpm;
                            }
                        }
                        if (74.0d <= time && time < 75d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }

                        //맨몸으로 부딪쳤던 내 삶에 그까짓 이별쯤은 괜찮아
                        if (75.0d <= time && time < 75.3d)
                        {
                            if (currentTime >= 23d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 23d / bpm;
                            }
                        }
                        if (75.3d <= time && time < 76d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        if (76d <= time && time < 76.3d)
                        {
                            if (currentTime >= 33d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 33d / bpm;
                            }
                        }
                        if (76.3d <= time && time < 77d)
                        {
                            if (currentTime >= 50d / bpm)
                            {
                                currentTime -= 50d / bpm;
                            }
                        }
                        if (77d <= time && time < 80d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }

                        // 마무리 결과창을 위한 출력
                        if (80d < time)
                        {
                            if (currentTime >= 500d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 500d / bpm;
                            }
                        }

                        //이대로 무너지면 절대로 안돼
                        /*if (80.6d <= time && time < 82d)
                        {
                            if (currentTime >= 62d / bpm)
                            {
                                GameObjectNote();
                                currentTime -= 62d / bpm;
                            }
                        }*/
                    }
                }
                break;
            default: break;
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
