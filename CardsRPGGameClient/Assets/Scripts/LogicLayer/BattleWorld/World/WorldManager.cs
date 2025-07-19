using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager
{
    private static BattleWorld mBattleWorld;
    
    /// <summary>
    /// 初始化
    /// </summary>
    public static void Initialize()
    {
        
    }

    /// <summary>
    /// 构建战斗世界
    /// </summary>
    public static void CreateBattleWorld()
    {
        mBattleWorld = new BattleWorld();
        mBattleWorld.OnCreate();
    }

    public static void OnUpdate()
    {
        if (mBattleWorld != null)
        {
            mBattleWorld.OnUpdate();
        }
    }

    /// <summary>
    /// 销毁世界
    /// </summary>
    public static void DestroyWorld()
    {
        mBattleWorld.OnDestroy();
    }
}
