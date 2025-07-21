using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRender : RenderObject
{

    public HeroData HeroData { get; private set; }
    public HeroTeamEnum HeroTeam{ get; private set; }
    
    public Animator mAnimator;
    public void SetHeroData(HeroData heroData, HeroTeamEnum heroTeam)
    {
        HeroData = heroData;
        HeroTeam = heroTeam;
        Initialize();
    }

    public void Initialize()
    {
        mAnimator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
    }

    public void PlayAnim(string animName)
    {
        mAnimator.SetTrigger(animName);
    }
    public override void OnRelease()
    {
        base.OnRelease();
    }
}
