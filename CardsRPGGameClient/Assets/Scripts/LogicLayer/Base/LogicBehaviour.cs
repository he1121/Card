using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicBehaviour
{
    public RenderObject RenderObj { get;protected set; } //渲染对象
    
    public VInt3 logicPosition { get; set; }// 逻辑位置
    
    public virtual void OnCreate()
    {
        
    }
    
    public virtual void OnLogicFrameUpdate()
    {
        
    }

    public virtual void OnDestroy()
    {
        
    }
}
