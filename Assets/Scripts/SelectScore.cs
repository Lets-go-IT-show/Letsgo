using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
// Firebase 불러오기

public class SelectScore : MonoBehaviour
{
    class Rank : IComparable
    {
        public static List<Rank> ranks = new List<Rank>();

        public string name;
        public int score;

        public Rank(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int CompareTo(object obj)
        {
            Rank r = (Rank)obj;
            //Debug.Log(this.score + " vs. " + r.score + " = " + this.score.CompareTo(r.score));
            return -1 * this.score.CompareTo(r.score);
        }
    }

    public DatabaseReference reference { get; set; }

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://letsgo-a2b88-default-rtdb.firebaseio.com/");

        reference = FirebaseDatabase.DefaultInstance.GetReference("rank");

        reference.GetValueAsync().ContinueWith(task => {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면

                Rank.ranks = new List<Rank>();
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary rank = (IDictionary)data.Value;
                    // Debug.Log("이름: " + rank["name"] + ", 점수: " + rank["score"]);
                    Rank.ranks.Add(new Rank(rank["name"].ToString(), int.Parse(rank["score"].ToString())));
                }


                Rank.ranks.Sort();

                foreach (var item in Rank.ranks)
                {
                    Debug.Log(item.name + " " + item.score);
                }
            }
        });


    }
}
