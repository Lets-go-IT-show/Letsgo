using Ardunity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player가 움직일 수 없도록 하는 변수
    public static bool s_canPresskey = true;

    TimingManager theTimingManager;
    private bool pauseOn = false;

    public AnalogInput input;

    void Start()
    {
        // 스페이스바가 눌리면 타이밍 판정을 할 수 있도록
        theTimingManager = FindObjectOfType<TimingManager>();

    }
    void Update()
    {
        if (s_canPresskey)
        {
            // 매 프레임마다 스페이스바가 눌러진 지 확인
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 판정 체크
                theTimingManager.CheckTiming();
            }
        }

        if(input.Value >= 1)
        {
            theTimingManager.CheckTiming();
        }

        if(s_canPresskey)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pauseOn)
                {
                    Time.timeScale = 0;
                    AudioManager.instance.StopBGM();
                }
                    
                else
                {
                    Time.timeScale = 1.0f;
                    AudioManager.instance.StopBGM();
                }
                    
                pauseOn = !pauseOn;
            }
        }

    }
}
