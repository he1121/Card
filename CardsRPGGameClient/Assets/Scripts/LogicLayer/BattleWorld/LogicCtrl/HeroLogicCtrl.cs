using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLogicCtrl : ILogicBehaviour
{
    public enum HeroTeamEnum
    {
        None,
        Self,
        Enemy
    }
    public void OnCreate()
    {
        
    }

    public void OnCreate(List<HeroData> playerHeroList, List<HeroData> enemyHeroList)
    {
#if CLIENT_LOGIC
        CreateHerosByList(playerHeroList, BattleWorldNodes.Instance.heroTransArr, HeroTeamEnum.Self);
        CreateHerosByList(enemyHeroList, BattleWorldNodes.Instance.enemyTransArr, HeroTeamEnum.Enemy);
#else
        CreateHerosByList(playerHeroList, null, HeroTeamEnum.Self);
        CreateHerosByList(enemyHeroList, null, HeroTeamEnum.Enemy);
#endif
    }

    public void OnLogicFrameUpdate()
    {
        
    }

    public void OnDestroy()
    {
        
    }

    /// <summary>
    /// 生成英雄
    /// </summary>
    /// <param name="heroList"></param>
    public void CreateHerosByList(List<HeroData> heroList, Transform[] parents, HeroTeamEnum heroTeamEnum)
    {
        foreach (var data in heroList)
        {
            GameObject heroObj = ResourcesManager.Instance.LoadObject("Prefabs/Hero/" + data.id, parents[data.seatId], true, true, false);
        }
    }
}
