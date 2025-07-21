using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTimerManager:Singleton<LogicTimerManager>, ILogicBehaviour
{
    public List<LogicTimer> mLogicTimerList = new List<LogicTimer>();
    public void OnCreate()
    {
        
    }

    public void DelayCall(VInt delayTime, Action callBack, float loop = 1)
    {
#if CLIENT_LOGIC
        LogicTimer logicTimer = new LogicTimer(delayTime, callBack, loop);
        mLogicTimerList.Add(logicTimer);


#else
        //服务端立即执行回调 无须延迟
        for (int i = 0; i < loop; i++)
        {
            callBack?.Invoke();
        }
#endif
    }
    
    public void OnLogicFrameUpdate()
    {
        foreach (var timer in mLogicTimerList)
        {
            timer.OnLogicFrameUpdate();
        }

        for (int i = mLogicTimerList.Count - 1; i >= 0; i--)
        {
            if (mLogicTimerList[i].isFinished)
            {
                mLogicTimerList.Remove(mLogicTimerList[i]);
            }
        }
    }

    public void OnDestroy()
    {
        mLogicTimerList.Clear();
    }
}
