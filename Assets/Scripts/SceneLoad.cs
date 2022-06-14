using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Slider와 Sceneager를 사용하기 위해서 UI와 SceneManagement 네임스페이스를 추가

public class SceneLoad : MonoBehaviour
{

    // 비동기 로드(LoadScenceAsyne)를 만들기 위해서 코루틴을 사용합니다
    // 비동기 로드는 Scene을 불러올 때 멈추지 않고 다른 작업을 할 수 있다
    // LodeScene()로 Scene을 불러오면 완료될 때까지 다른 작업을 수행하지 않습니다
    public Slider progressbar;
    public Text loadtext;

    // Start함수 안에서 LoadScene를 실행합니다
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(3); // Play를 비동기식으로 불러온다
        // 이때 LoadSceneAsync가 AsycnOperation을 반환하니 담아줍니다
        operation.allowSceneActivation = false;

        // 반복문 : Slider의 value를 매 프레임증가
        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                loadtext.text = "Press SpaceBar";
            }

            if (Input.GetKeyDown(KeyCode.Space) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }



    /* 
    AsyncOperation 속성 
     : isDone은 작업의 완료 유무를 boolean 형으로 반환합니다
     : progress는 진행정도를 float형 0,1을 반환합니다 (0 : 진행중, 1 : 진행완료)
     : allowSceneActivation은 true면 로딩이 완료되면 바로 신을 넘기고 false이면 progress가 0.9f에서 정지
       이때 다시 true를 해야 불러온 Scene으로 넘어갈 수 있다
    
    operation.isDone;
    operation.progress;
    operation.allowSceneActivation;
    */

}
