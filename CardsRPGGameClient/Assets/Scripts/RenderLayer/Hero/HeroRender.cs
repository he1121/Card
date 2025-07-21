using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroRender : RenderObject
{

    public HeroData HeroData { get; private set; }
    public HeroTeamEnum HeroTeam{ get; private set; }
    
    public Animator mAnimator;
    private HeroHUDComponent mHeroHud;
    private Transform mHudParent;
    public void SetHeroData(HeroData heroData, HeroTeamEnum heroTeam)
    {
        HeroData = heroData;
        HeroTeam = heroTeam;
        Initialize();
    }

    public void Initialize()
    {
        mAnimator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        mHeroHud =
            ResourcesManager.Instance.LoadObject<HeroHUDComponent>(AssetPathConfig.HUD + "HPObject" +
                                                                   HeroTeam.ToString(), BattleWorldNodes.Instance.HUDWindowTrans);
        mHudParent = transform.Find("HUDParent").transform;
        mHeroHud.Init(this);
    }

    public void PlayAnim(string animName)
    {
        mAnimator.SetTrigger(animName);
    }

    public override void Update()
    {
        base.Update();
        UpdateHeroHUD();
    }

    //更新血条显示
    public void UpdateHP_HUD(int damage, float hpRateValue)
    {
        GameObject damageTextObj = ResourcesManager.Instance.LoadObject(AssetPathConfig.HUD + (damage>0?"DamageText" : "RestoreHPText"),
            BattleWorldNodes.Instance.HUDWindowTrans, resetScale:true);
        Vector2 canvasPos = World3DToCanvasPos(transform.position);
        damageTextObj.transform.localPosition = new Vector2(canvasPos.x, canvasPos.y+40);
        damageTextObj.GetComponent<Text>().text = (damage > 0 ? "-":"+")+Mathf.Abs(damage);
        damageTextObj.transform.DOLocalMoveY(damageTextObj.transform.localPosition.y + 100, 1f);
        damageTextObj.GetComponent<CanvasGroup>().DOFade(0, 0.5f).SetDelay(1.2f);
        Destroy(damageTextObj, 3f);
        
        mHeroHud.UpdateHPSlider(hpRateValue);
    }

    //更新血条跟随英雄
    public void UpdateHeroHUD()
    {
        if(mHudParent != null && mHeroHud != null && LogicObj !=null)
        {
            mHeroHud.transform.localPosition = World3DToCanvasPos(mHudParent.position);
        }
    }
    
    public Vector3 World3DToCanvasPos(Vector3 targetPos)
    {
        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(BattleWorldNodes.Instance.Camera3D, targetPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            BattleWorldNodes.Instance.HUDWindowTrans as RectTransform, screenPos, BattleWorldNodes.Instance.UICamera,
            out var uGUILocalPos);
        return uGUILocalPos;
    }
    public override void OnRelease()
    {
        base.OnRelease();
    }
}
