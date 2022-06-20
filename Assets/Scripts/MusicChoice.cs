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
        musicName = "TomBoy";
        Debug.Log("톰보이호출 : " + musicName);
    }

    public void Music03()
    {
        musicIndex = 2;
        musicName = "폼생폼사";
        Debug.Log("폼생폼사호출 : " + musicName);
    }
}
