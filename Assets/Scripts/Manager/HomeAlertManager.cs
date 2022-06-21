using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAlertManager : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;

    public void ShowAlter()
    {
        AudioManager.instance.StopBGM();
        goUI.SetActive(true);

        if (Time.timeScale == 0) //멈춰있으면
        {
            Time.timeScale = 1f; //시작
        }
        else //움직이면
        {
            Time.timeScale = 0; //멈추기
        }

    }

    public void noteStart()
    {
        AudioManager.instance.StopBGM();
        if (Time.timeScale == 0) //멈춰있으면
        {
            Time.timeScale = 1f; //시작
            goUI.SetActive(false); // 알림창 가리기
        }
        else //움직이면
        {
            Time.timeScale = 0; //멈추기
        }
    }


}
