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
    public Text LoveDive_Rank_Score = null;
    public Text Tamed_Rank_Score = null;
    public Text WiIng_Rank_Score = null;

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
                    Rank.ranks.Add(new Rank(rank["music"].ToString(), rank["name"].ToString(), int.Parse(rank["score"].ToString())));
                }

                Rank.ranks.Sort();

                int[] cnt = new int[3];

                foreach (var item in Rank.ranks)
                {
                    String userName = item.name;
                    if (item.music == "TomBoy" && cnt[0] < 5)
                    {
                        if (item.name.Length >= 6) userName = userName.Substring(0,5) + "...";
                        // LoveDive_Rank.text += userName + "      "+ item.score + "점\n\n";
                            LoveDive_Rank.text += userName + "\n\n";
                            LoveDive_Rank_Score.text += item.score + "점\n\n";
                            cnt[0]++;
                    }
                    else if (item.music == "TamedDashed" && cnt[1] < 5)
                    {
                        if (item.name.Length >= 6) userName = userName.Substring(6)+"...";
                            Tamed_Rank.text += userName + "\n\n";
                            Tamed_Rank_Score.text += item.score + "점\n\n";
                            cnt[1]++;
                    }
                    else if (item.music == "폼생폼사" && cnt[2] < 5)
                    {
                        if (item.name.Length >= 6) userName = userName.Substring(6) + "...";
                            WiIng_Rank.text += userName + "\n\n";
                            WiIng_Rank_Score.text += item.score + "점\n\n";
                            cnt[2]++;
                    }
                }
            }
        });
    }
}