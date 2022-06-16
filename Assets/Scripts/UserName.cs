using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class UserName : MonoBehaviour
{
    // Start is called before the first frame update

    // 닉네임 받아오는 변수
    public InputField inputname;
    public static string username;

    public void Start()
    {
        username = inputname.GetComponent<InputField>().text;
        Debug.Log("start : " + username);
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public string GetUserName()
    {
        Debug.Log("이름 호출 : " + username);
        return username;
    }
}