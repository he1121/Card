using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroHUDComponent : MonoBehaviour
{
    private HeroRender mHeroRender;
    public Slider hpSlider;
    public Slider hpDamageAnimSlider; //血量过渡动画slider
    public Slider rageSlider;
    public Transform buffParent;

    public void Init(HeroRender heroRender)
    {
        mHeroRender = heroRender;
    }

    public void UpdateHPSlider(float value)
    {
        hpSlider.value = value;
        hpDamageAnimSlider.DOValue(value, 0.5f).SetDelay(0.4f);
        if (value <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
