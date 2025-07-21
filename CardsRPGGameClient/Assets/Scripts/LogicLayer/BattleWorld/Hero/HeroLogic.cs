using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLogic : LogicObject
{
    protected VInt hp;
    protected VInt atk;
    protected VInt def;
    protected VInt agl;
    protected VInt rage;
    
    public VInt Hp => hp;
    public VInt MaxHp { get; protected set; }
    public VInt Atk => atk;
    public VInt Def => def;
    public VInt Agl => agl;
    public VInt Rage => rage;
    public VInt MaxRage => 100;

    public int id => HeroData.id;
    public HeroData HeroData { get; private set; }
    public HeroRender heroRender { get; private set; }
    public HeroTeamEnum HeroTeam { get; private set; }
    public HeroLogic(HeroData heroData, HeroTeamEnum heroTeam)
    {
        HeroData = heroData;
        HeroTeam = heroTeam;
        hp = heroData.hp;
        atk = heroData.atk;
        def = heroData.def;
        agl = heroData.agl;
        MaxHp = hp;
        rage = heroData.atkRage;
    }
    
    public override void OnCreate()
    {
        base.OnCreate();
        Debugger.Log("HeroName:"+ RenderObj.gameObject.name);
        heroRender = (HeroRender)RenderObj;
    }

    public override void OnLogicFrameUpdate()
    {
        base.OnLogicFrameUpdate();
    }
    
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    
    public void PlayAnim(string animName)
    {
#if RENDER_LOGIC
        heroRender.PlayAnim(animName);
#endif
    }

    /// <summary>
    /// 扣血
    /// </summary>
    /// <param name="damageHp"></param>
    public void DamageHP(VInt damageHp)
    {
        if(damageHp <= 0)
            return;
        hp -= damageHp;
        if (hp < 0)
        {
            hp = 0;
            HeroDead();
            return;
        }
        else
        {
            PlayAnim("OnHit");
        }
        Debugger.Log("英雄id"+ id + "英雄损失血量:"+ damageHp + " 当前血量:" + hp);
    }

    public void HeroDead()
    {
        
    }
}
