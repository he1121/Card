using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWorldNodes : SingletonMono<BattleWorldNodes>
{
    //英雄父节点
    public Transform[] heroTransArr;
    
    public Transform[] enemyTransArr;
    
    public Transform HUDWindowTrans;

    public Camera Camera3D;
    public Camera UICamera;
}
