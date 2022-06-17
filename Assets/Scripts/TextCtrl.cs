using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class TextCtrl : MonoBehaviour
{
    private int Score = 0;
    public Text ScoreText1 = null;

    /*void Update()
    {
        ScoreText.text = "누른 횟수 : " + Score.ToString();
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) Score++; // Fire1 = 좌클릭, Fire2 = 우클릭
    }*/


    class Rank : IComparable
    {
        public static List<Rank> ranks = new List<Rank>();

        public string name;
        public int score;
        public string music;

        public Rank(string music, string name, int score)
        {
            this.music = music;
            this.name = name;
            this.score = score;
        }

        public int CompareTo(object obj)
        {
            Rank r = (Rank)obj;
            //Debug.Log(this.score + " vs. " + r.score + " = " + this.score.CompareTo(r.score));
            return -1 * this.score.CompareTo(r.score);
            // return this.score.CompareTo(r.score);
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
                    Rank.ranks.Add(new Rank(rank["music"].ToString(), rank["name"].ToString(), int.Parse(rank["score"].ToString())));
                }


                Rank.ranks.Sort();


                int cnt = 0;

                foreach (var item in Rank.ranks)
                {

                    if (cnt > 6) { break; }

                    else
                    {
                        ScoreText1.text += item.music + "    " + item.name + "    " + item.score + "점\n";
                        cnt++;
                    }

                    Debug.Log(item.name + " " + item.score);

                    // ScoreText1.text += item.name + "          " + item.score+"점\n";


                }

            }
        });


    }
}