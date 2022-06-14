using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// PlayBtn에서 Scene을 불러오는데 SecneManager를 사용하기 위해서 네임스페이스 추가


public class Main : MonoBehaviour
{
    // PlayBtn을 버튼의 OnClick이벤트에 연결
    // PlayBtn에서 SceneManager를 이용해서 Loading을 불러온다

    // 레쭈고 메인 화면
    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }

    // 메뉴로 화면 전환
    public void PlayBtn()
    {
        //SceneManager.LoadScene("불러올 씬이름 or 번호");
        SceneManager.LoadScene("Menu");
    }

    // 이름 입력창
    public void GameName()
    {
        SceneManager.LoadScene("Name");
    }

    // 메뉴에서 시작 -> 게임 시작
    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // 메뉴에서 시작 -> 순위
    public void GameRank()
    {
        SceneManager.LoadScene("Rank");
    }

    // 메뉴에서 방법 -> 게임 방법
    public void GameRole()
    {
        SceneManager.LoadScene("Role");
    }


    public void GameRole_2()
    {
        SceneManager.LoadScene("Role_2");
    }


}
