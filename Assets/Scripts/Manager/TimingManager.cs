using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    // 생성된 노트를 담는 List => 판정 범위에 있는지 모든 노트를 비교해야함
    public List<GameObject> boxNoteList = new List<GameObject>();

    // 판정들을 기억할 배열 변수 - result
    int[] judgementRecord = new int[5];


    // 판정 범위의 센터를 알려주는 변수
    [SerializeField] Transform Center = null;
    // 다양한 판정을 보여줄 배열 
    [SerializeField] RectTransform[] timingRect = null;

    // 실제 판정 범위의 최소값(x), 최대값(y), RectTransform배열의 값을 정리해서 넣어줌
    Vector2[] timingBoxs = null;

    EffectManager theEffect;
    // ScoreManager 참고
    ScoreManager theScoreManager;
    ComboManager theComboManager;

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();

        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];

        // 0번째 TimingBox = Perfect(가장 좁은 판정)
        // 3번째 TimingBox = Bad(가장 넓은 판정)
        for (int i = 0; i < timingRect.Length; i++)
        {
            // 최소값 = 중심 - (이미지의 너비/2)
            // 최대값 = 중심 + (이미지의 너비/2)
            // => x에서 y 사이의 값이 판정 범위가 됨
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    // 판정 함수
    public void CheckTiming()
    {
        // 타이밍을 체크하는 함수 안에 
        // 리스트에 있는 노트들을 확인해서 판정 박스에 있는 노트를 찾아야함
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            // 판정 범위 최소값 <= 노트의 x값 <= 판정범위 최대값
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            // 각 노트마다 판정 범위 안에 있는지 확인
            for (int x = 0; x < timingBoxs.Length; x++) // 판정 범위 만큼 반복 => 어느 판정 위에 있는지 확인
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    // *노트 제거
                    // 노트의 이미지만 없애고 파괴되지 않도록 설정
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    // *이펙트 연출
                    // 연출재생 조건 : 0: Perfect, 1: Cool, 2:Good, 3: Bad
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();

                    theScoreManager.IncreaseScore(x); // 점수 증가
                    // bad에 점수를 주기 싫다면 판정 연출 조건문 안에 끼워넣기 
                    // x의 값을 파라미터로 넘기기
                    theEffect.JudgementEffect(x); // 판정 연출
                    judgementRecord[x]++; // 판정 기록

                    return;
                }
            }
        }
        // miss 뜨는 위치에 combo reset
        theComboManager.ResetCombo();
        // timingBoxs의 배열 개수는 4이므로 length를 이용
        theEffect.JudgementEffect(timingBoxs.Length);
        MissRecord();
    }

    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

    public void MissRecord()
    {
        judgementRecord[4]++; // 판정 기록
    }
}
