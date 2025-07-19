using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private void Awake()
    {
        WorldManager.Initialize();
        
        List<HeroData> playerHeroList = new List<HeroData>();
        List<HeroData> enemyHeroList = new List<HeroData>();
        
        //测试英雄
        List<int> heroIdList = new List<int> { 101, 102, 103, 104, 105, 501, 502, 503, 504, 505 };
        for (int i = 0; i < heroIdList.Count; i++)
        {
            HeroData hero = new HeroData();
            if (i < 5)
            {
                //前5个为玩家英雄
                hero.id = heroIdList[i];
                hero.seatId = i;
                playerHeroList.Add(hero);
            }
            else
            {
                //后5个为敌方英雄
                hero.id = heroIdList[i];
                hero.seatId = i - 5;
                enemyHeroList.Add(hero);
            }
        }
        WorldManager.CreateBattleWorld(playerHeroList, enemyHeroList);
    }

    private void Update()
    {
        WorldManager.OnUpdate();
    }

    private void OnDestroy()
    {
        WorldManager.DestroyWorld();
    }
}
