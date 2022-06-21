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
    public Text alertmessage;

    public void Start()
    {
        
    }

    public void GameName()
    {
        SceneManager.LoadScene("Name");
    }

    public string GetUserName()
    {
        Debug.Log("이름 호출 : " + username);
        return username;
    }

    public void btnNextOnClick()
    {
        username = inputname.GetComponent<InputField>().text;
        if (username == "" || username == null)
        {
            alertmessage.text = "닉네임을 입력해주세요.";
        }
        else
        {
            alertmessage.text = "";
            SceneManager.LoadScene("ChooseMusic");

        }
    }
}