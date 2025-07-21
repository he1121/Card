using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroTeamEnum
{
    None,
    Self,
    Enemy
}

public class HeroLogicCtrl : ILogicBehaviour
{
    public List<HeroLogic> allHeroList = new List<HeroLogic>();
    public List<HeroLogic> heroList = new List<HeroLogic>();
    public List<HeroLogic> enemyList = new List<HeroLogic>();
    public void OnCreate()
    {
        
    }

    public void OnCreate(List<HeroData> playerHeroList, List<HeroData> enemyHeroList)
    {
#if CLIENT_LOGIC
        CreateHerosByList(playerHeroList, heroList, BattleWorldNodes.Instance.heroTransArr, HeroTeamEnum.Self);
        CreateHerosByList(enemyHeroList, enemyList, BattleWorldNodes.Instance.enemyTransArr, HeroTeamEnum.Enemy);
#else
        CreateHerosByList(playerHeroList, heroList, null, HeroTeamEnum.Self);
        CreateHerosByList(enemyHeroList, enemyList, null, HeroTeamEnum.Enemy);
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
    /// <param name="heroLogicList"></param>
    /// <param name="parents"></param>
    /// <param name="heroTeamEnum"></param>
    public void CreateHerosByList(List<HeroData> heroList, List<HeroLogic> heroLogicList, Transform[] parents, HeroTeamEnum heroTeamEnum)
    {
        foreach (var data in heroList)
        {
            HeroLogic heroLogic = new HeroLogic(data, heroTeamEnum);
#if CLIENT_LOGIC
            GameObject heroObj = ResourcesManager.Instance.LoadObject("Prefabs/Hero/" + data.id, parents[data.seatId], true, true, true);
            HeroRender heroRender = heroObj.GetComponent<HeroRender>();
            heroLogic.SetRenderObject(heroRender);
            heroRender.SetLogicObject(heroLogic);
            heroRender.SetHeroData(data, heroTeamEnum);
#endif
            heroLogic.OnCreate();
            heroLogicList.Add(heroLogic);
            allHeroList.Add(heroLogic);
        }
    }
}
