using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    // 결과창 변수
    [SerializeField] GameObject goUI = null;

    // perfect cool good 넣어주기
    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtMaxCombo = null;

    ScoreManager theScore;
    ComboManager theCombo;
    // 판정의 대한 기록
    TimingManager theTiming;


    // Start is called before the first frame update
    void Start()
    {
        theScore = FindObjectOfType<ScoreManager>();
        theCombo = FindObjectOfType<ComboManager>();
        theTiming = FindObjectOfType<TimingManager>();
    }

    public void ShowResult()
    {
        // UI 활성화
        goUI.SetActive(true);
        // 모든 text 초기화
        for (int i = 0; i < txtCount.Length; i++)
        {
            txtCount[i].text = "0";
        }
        txtScore.text = "0";
        txtMaxCombo.text = "0";

        int[] t_judgement = theTiming.GetJudgementRecord();
        int t_currentScore = theScore.GetCurrentScore();
        int t_maxCombo = theCombo.GetMaxCombo();

        for (int i = 0; i < txtCount.Length; i++)
        {
            // 판정들이 text에 들어감
            txtCount[i].text = string.Format("{0:#,##0}", t_judgement[i]);
        }

        txtScore.text = string.Format("{0:#,##0}", t_currentScore);
        txtMaxCombo.text = string.Format("{0:#,##0}", t_maxCombo);
    }
}
