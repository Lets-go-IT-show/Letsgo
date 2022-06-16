using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

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

    class Rank
    {
        public string name;
        public int score;

        public Rank(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public DatabaseReference reference { get; set; }


    // Start is called before the first frame update
    public void Start()
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

        // 콘솔로 점수 찍히는 지 확인
        Debug.Log("콘솔로 점수 넘어오는 지 확인 : " + theScore.GetCurrentScore());

        // firebase로 점수 넘김
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://letsgo-a2b88-default-rtdb.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;


        // Debug.Log("usrename넘어오는지 확인 : " + UserName.username);
        UserName theName = new UserName();
        Debug.Log("구오이 점수 콘솔 : " + theScore.GetCurrentScore());
        Rank rank = new Rank(UserName.username, theScore.GetCurrentScore());
        string json = JsonUtility.ToJson(rank);

        string key = reference.Child("rank").Push().Key;
        reference.Child("rank").Child(key).SetRawJsonValueAsync(json);

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
