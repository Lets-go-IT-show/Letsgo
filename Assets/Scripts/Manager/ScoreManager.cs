using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 텍스트 변수
    [SerializeField] UnityEngine.UI.Text txtScore = null;

    // 몇 점씩 올라가게 할지 만드는 디폴트 변수
    [SerializeField] int increaseScore = 10;
    // 현재 점수
    int currentScore = 0;

    // 판정에 따라 다른 점수가 들어올 수 있도록 할 배열
    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;

    Animator myAnim;
    // ScoerUp 파라미터를 담을 변수
    string animScoreUp = "ScoreUp";

    // ComboManager 참조
    ComboManager theCombo;

    void Start()
    {
        theCombo = FindObjectOfType<ComboManager>();
        // GetComponent로 animator를 가져와 채워주기
        myAnim = GetComponent<Animator>();
        // 시작과 동시에 값을 0으로 초기화
        currentScore = 0;
        txtScore.text = "0";
    }


    // 어떤 판정을 받았는지
    public void IncreaseScore(int p_JudgementState)
    {
        // 콤보 증가
        theCombo.IncreaseCombo();

        // 콤보 보너스 점수 계산
        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        // 판정 가중치 계산
        int t_increaseScore = increaseScore + t_bonusComboScore;
        // 3이 넘어오면 0.1 곱해주는 식
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]); // perfect가 0

        // 점수 반영
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore); // 문자열 형식 : 소수섬, 날짜 표현 형식으로 변환

        // 애니메이션 실행
        myAnim.SetTrigger(animScoreUp);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
