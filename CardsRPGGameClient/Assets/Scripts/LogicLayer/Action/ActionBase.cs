using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBase : ILogicBehaviour
{
    public bool actionComplete = false; //移动是否完成
    public void OnCreate()
    {
        
    }

    public virtual void OnLogicFrameUpdate()
    {
        
    }

    public void OnDestroy()
    {
        
    }
}
