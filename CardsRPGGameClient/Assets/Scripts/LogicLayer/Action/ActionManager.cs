using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager: Singleton<ActionManager>, ILogicBehaviour
{
    /// <summary>
    /// 所有行动操作
    /// </summary>
    public List<ActionBase> mActionList = new List<ActionBase>();
    public void OnCreate()
    {
        
    }

    public void RunAction(ActionBase action)
    {
#if CLIENT_LOGIC
        mActionList.Add(action);
#else
        OnLogicFrameUpdate();
#endif
    }
    
    public void OnLogicFrameUpdate()
    {
        foreach (var action in mActionList)
        {
            action.OnLogicFrameUpdate();
        }

        for (int i = mActionList.Count - 1; i >= 0; i--)
        {
            if(mActionList[i].actionComplete)
                mActionList.Remove(mActionList[i]);
        }
    }

    public void OnDestroy()
    {
        
    }
}
