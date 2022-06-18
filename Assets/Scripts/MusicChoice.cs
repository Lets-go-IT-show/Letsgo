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
        musicname = "TamedDashed";
        Debug.Log("템데호출 : " + musicname);
    }

    public void Music02()
    {
        musicname = "LoveDive";
        Debug.Log("럽다호출 : " + musicname);
    }

    public void Music03()
    {
        musicname = "WiIngWiIng";
        Debug.Log("위잉위잉호출 : " + musicname);
    }
}
