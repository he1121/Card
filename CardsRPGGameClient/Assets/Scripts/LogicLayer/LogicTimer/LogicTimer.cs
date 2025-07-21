using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTimer : ILogicBehaviour
{
    public bool isFinished ; //是否完成
    public VInt delayTime; //延迟时间
    public Action callBack; //回调函数
    public float loop;
    
    private VInt curAccumulatedTime; //当前累计时间
    public LogicTimer(VInt delayTime, Action callBack, float loop = 1)
    {
        this.delayTime = delayTime;
        this.callBack = callBack;
        this.loop = loop;
    }
    public void OnCreate()
    {
        
    }
    public void OnLogicFrameUpdate()
    {
        curAccumulatedTime += (VInt)LogicFrameSyncConfig.LogicFrameIntervalMs;
        if (curAccumulatedTime >= delayTime && loop > 0)
        {
            callBack?.Invoke();
            curAccumulatedTime = 0;
            loop--;
            if (loop == 0)
            {
                isFinished = true;
            }
        }
    }

    public void OnDestroy()
    {
        
    }
}
