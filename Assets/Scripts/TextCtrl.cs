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
    public Text LoveDive_Rank = null;
    public Text Tamed_Rank = null;
    public Text WiIng_Rank = null;

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


                int[] cnt = new int[3];

                foreach (var item in Rank.ranks)
                {
                    if (item.music == "TomBoy" && cnt[0] < 4)
                    {
                        LoveDive_Rank.text += item.name + "    " + item.score + "점\n";
                        cnt[0]++;
                    }
                    else if (item.music == "TamedDashed" && cnt[1] < 4)
                    {
                        Tamed_Rank.text += item.name + "    " + item.score + "점\n";
                        cnt[1]++;
                    }
                    else if (item.music == "폼생폼사" && cnt[2] < 4)
                    {
                        WiIng_Rank.text += item.name + "    " + item.score + "점\n";
                        cnt[2]++;
                    }


                }

            }
        });


    }
}