using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWorld
{
    public HeroLogicCtrl HeroLogic;
    public RoundLogicCtrl RoundLogic;

    private float mAccLogicFrameRunTime; // 逻辑帧累计运行时间
    private float mNextLogicFrameTime; // 下一个逻辑帧时间
    public static float deltaTime; // 动画缓动时间
    
    /// <summary>
    /// 战斗世界创建时触发
    /// </summary>
    public void OnCreate(List<HeroData> playerHeroList, List<HeroData>enemyHeroList)
    {
        HeroLogic = new HeroLogicCtrl();
        RoundLogic = new RoundLogicCtrl();
        
        HeroLogic.OnCreate(playerHeroList, enemyHeroList);
        RoundLogic.OnCreate();
    }
    
    public void OnUpdate()
    {
#if CLIENT_LOGIC
        mAccLogicFrameRunTime += Time.deltaTime;
        //当前逻辑帧累计时间若大于下一个逻辑帧时间，则更新逻辑帧
        //控制帧数 保证所有设备逻辑帧帧数一致 并进行追帧操作
        while (mAccLogicFrameRunTime > mNextLogicFrameTime)
        {
            OnLogicFrameUpdate();
            //计算下一逻辑帧运行时间
            mNextLogicFrameTime += LogicFrameSyncConfig.LogicFrameInterval;
            //逻辑帧id自增
            LogicFrameSyncConfig.LogicFrameId++;
        }

        // Debugger.Log("逻辑帧id:"+LogicFrameSyncConfig.LogicFrameId);
        deltaTime = (mAccLogicFrameRunTime + LogicFrameSyncConfig.LogicFrameInterval - mNextLogicFrameTime) /
                    LogicFrameSyncConfig.LogicFrameInterval;
#else
        OnLoginicFrameUpdate();
#endif
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HeroLogic.heroList[0].PlayAnim("Attack");
            Debugger.Log("计时开始"+Time.realtimeSinceStartup);
            MoveToAction moveTo = new MoveToAction(HeroLogic.heroList[0], HeroLogic.enemyList[0].logicPosition, 1000,
                () =>
                {
                    Debugger.Log("计时结束"+Time.realtimeSinceStartup);
                    Debugger.Log("移动完成 pos" + HeroLogic.heroList[0].logicPosition);
                    SkillEffect skillEffect = ResourcesManager.Instance.LoadObject<SkillEffect>("Prefabs/SkillEffect/Effect_RenMa_hit");
                    skillEffect.SetEffectPos(HeroLogic.enemyList[0].logicPosition);
                    HeroLogic.heroList[0].DamageHP(20);
                });
            ActionManager.Instance.RunAction(moveTo);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveToAction moveTo = new MoveToAction(HeroLogic.heroList[0], new VInt3(BattleWorldNodes.Instance.heroTransArr[0].position), 1000,
                () =>
                {
                    Debugger.Log("移动完成 pos" + HeroLogic.heroList[0].logicPosition);
                });
            ActionManager.Instance.RunAction(moveTo);
        }
    }
    
    /// <summary>
    /// 逻辑帧更新
    /// </summary>
    public void OnLogicFrameUpdate()
    {
        HeroLogic?.OnLogicFrameUpdate();
        RoundLogic?.OnLogicFrameUpdate();
        ActionManager.Instance.OnLogicFrameUpdate();
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
