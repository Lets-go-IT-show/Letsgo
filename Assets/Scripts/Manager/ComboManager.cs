using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    // 콤보 이미지, 텍스트 변수
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] UnityEngine.UI.Text txtCombo = null;

    // 현재 콤보
    int currentCombo = 0;
    int maxCombo = 0;

    // 처음부터 콤보를 보여주지 않기 위한 함수
    void Start()
    {
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    // 콤보 증가 함수
    // 파라미터가 넘어오지 않으면 1을 기본값으로 증가
    public void IncreaseCombo(int p_num = 1)
    {
        // 몇 콤보씩 증가할 것인지
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (maxCombo < currentCombo)
            maxCombo = currentCombo;

        // 콤보 텍스트와 이미지는 3 콤보 이상부터 출력
        if (currentCombo > 2)
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);
        }
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    // 콤보 초기화
    public void ResetCombo()
    {
        currentCombo = 0;
        txtCombo.text = "0";
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }
}
