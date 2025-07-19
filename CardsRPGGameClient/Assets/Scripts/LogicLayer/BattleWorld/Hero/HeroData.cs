using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData
{
    public HeroData()
    {
        
    }
    public int seatId; // 座位id
    public int id;
    public string name;
    public int type;
    public int[] skillIdArr;
    public int hp;
    public int atk;
    public int def;
    public int agl;
    public int atkRage; //攻击回复怒气值
    public int takeDamageRage; //受击回复怒气值
    public int maxRage; //怒气值上限
}
