using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LogicObjectState
{
    Survival,
    Death, 
    SurvivalWating//存活等待
}
public class LogicObject : LogicBehaviour
{
    //默认存活状态
    public LogicObjectState ObjectState = LogicObjectState.Survival;
    public void SetRenderObject(RenderObject renderObject)
    {
        ObjectState = LogicObjectState.Survival;
        RenderObj = renderObject;
        logicPosition = new VInt3(renderObject.transform.position);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
#if CLIENT_LOGIC
        RenderObj.OnRelease();
#endif
    }
}
