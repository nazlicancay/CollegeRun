using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider;

    public void SetScore(int score )
    {
        score = Mathf.Clamp(score, 0, 180);
        //Slider.value = score;
        DOTween.To(()=> Slider.value, x=> Slider.value = x, score, 0.3f);
    }

   

}
