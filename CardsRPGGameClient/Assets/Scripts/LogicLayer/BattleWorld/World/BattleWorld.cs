using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWorld
{
    public HeroLogicCtrl HeroLogic;
    public RoundLogicCtrl RoundLogic;
    /// <summary>
    /// 战斗世界创建时触发
    /// </summary>
    public void OnCreate()
    {
        HeroLogic = new HeroLogicCtrl();
        RoundLogic = new RoundLogicCtrl();
        
        HeroLogic.OnCreate();
        RoundLogic.OnCreate();
    }
    
    public void OnUpdate()
    {
        // 更新逻辑
    }
    
    /// <summary>
    /// 逻辑帧更新
    /// </summary>
    public void OnLogicFrameUpdate()
    {
        HeroLogic?.OnLogicFrameUpdate();
        RoundLogic?.OnLogicFrameUpdate();
    }

    /// <summary>
    /// 战斗世界销毁时触发
    /// </summary>
    public void OnDestroy()
    {
        HeroLogic.OnDestroy();
        RoundLogic.OnDestroy();
    }
}
