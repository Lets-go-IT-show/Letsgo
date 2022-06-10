using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";

    // 새로운 Animator변수
    [SerializeField] Animator judgementAnimator = null;

    // 교체할 이미지 변수
    [SerializeField] UnityEngine.UI.Image judgementImage = null;

    // 판정에 따라 다른 이미지를 담을 변수, ex) GOOD
    [SerializeField] Sprite[] judgementSprite = null;

    public void JudgementEffect(int p_num)
    {
        // 파라미터 값에 맞는 판정 이미지 스프라이트로 교체
        judgementImage.sprite = judgementSprite[p_num];

        judgementAnimator.SetTrigger(hit);
    }

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }
}
