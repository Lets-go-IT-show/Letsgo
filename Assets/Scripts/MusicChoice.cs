using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChoice : MonoBehaviour
{
    public static string musicName;
    public static int musicIndex;

    public void Start()
    {

    }

    public void Music01()
    {
        musicIndex = 0;
        musicName = "TamedDashed";
        Debug.Log("템데호출 : " + musicName);
    }

    public void Music02()
    {
        musicIndex = 1;
        musicName = "LoveDive";
        Debug.Log("럽다호출 : " + musicName);
    }

    public void Music03()
    {
        musicIndex = 2;
        musicName = "WiIngWiIng";
        Debug.Log("위잉위잉호출 : " + musicName);
    }
}
