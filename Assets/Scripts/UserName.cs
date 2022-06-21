using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class UserName : MonoBehaviour
{
    // Start is called before the first frame update

    // 닉네임 받아오는 변수
    public InputField inputname;
    public static string username;
    public Text alertmessage = null;

    public void Start()
    {
        username = inputname.GetComponent<InputField>().text;

        if (username == "")
        {
            Debug.Log("null이 들어오는 지  : " + username);
            alertmessage.text += "닉네임을 입력해주세요";

        }
        else
        {
            Debug.Log("이름 뭐로 찍히나 : " + username);

            /*if (MusicChoice.musicIndex == 0)
            {
                SceneManager.LoadScene("TamedDashed");
            }
            else if (MusicChoice.musicIndex == 1)
            {
                SceneManager.LoadScene("TomBoy");
            }
            else if (MusicChoice.musicIndex == 2)
            {
                SceneManager.LoadScene("Thewaythisguylives");
            }*/
            ChooseMusic();

        }

        Debug.Log("start : " + username);
    }

    public void GameName()
    {
        SceneManager.LoadScene("Name");
    }

    public void ChooseMusic()
    {
        SceneManager.LoadScene("ChooseMusic");
    }

    public string GetUserName()
    {
        Debug.Log("이름 호출 : " + username);
        return username;
    }
}