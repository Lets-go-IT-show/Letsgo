using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChoice : MonoBehaviour
{
    public static string musicname;

    public void Start()
    {

    }

    public void Music01()
    {
        musicname = "Tamed Dashed";
        Debug.Log("템데호출 : " + musicname);
    }

    public void Music02()
    {
        musicname = "LOVE DIVE";
        Debug.Log("럽다호출 : " + musicname);
    }

    public void Music03()
    {
        musicname = "위잉위잉";
        Debug.Log("위잉위잉호출 : " + musicname);
    }
}
