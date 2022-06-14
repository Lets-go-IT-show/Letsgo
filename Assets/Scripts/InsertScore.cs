using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
// Firebase 불러오기

public class InsertScore : MonoBehaviour
{
    class Rank
    {
        public string name;
        public int score;

        public Rank(string name, int score)
        {
            // 초기화하기 쉽게 생성자 사용
            this.name = name;
            this.score = score;
        }
    }

    public DatabaseReference reference { get; set; }
    // 라이브러리를 통해 불러온 FirebaseDatabase 관련객체를 선언해서 사용

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://letsgo-a2b88-default-rtdb.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // 데이터베이스 경로를 설정해 인스턴스를 초기화
        // Database의 특정지점을 가리킬 수 있는데, 그 중 RootReference를 가리킴

        Rank rank = new Rank("이호걸", 777);
        string json = JsonUtility.ToJson(rank);
        // 데이터를 json형태로 반환

        string key = reference.Child("rank").Push().Key;
        // root의 자식 rank에 key 값을 추가해주는 것임

        reference.Child("rank").Child(key).SetRawJsonValueAsync(json);
        // 생성된 키의 자식으로 json데이터를 삽입
    }
}