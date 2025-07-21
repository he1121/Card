using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderObject : MonoBehaviour
{
    public LogicObject LogicObj;
    public virtual void SetLogicObject(LogicObject logicObject)
    {
        LogicObj = logicObject;
    }

    public virtual void Update()
    {
        if(LogicObj == null)
            return;
        //渲染层角色移动
        transform.position = Vector3.Lerp(transform.position, LogicObj.logicPosition.vec3, BattleWorld.deltaTime);
    }
    public virtual void OnRelease()
    {
        GameObject.Destroy(gameObject);
    }
}
