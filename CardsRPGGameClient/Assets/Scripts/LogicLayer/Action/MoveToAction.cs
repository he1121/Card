using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAction : ActionBase
{
    private LogicObject mMoveLogicObject; //要移动的对象
    private VInt3 mTargetPos; //目标位置
    private VInt mTime; //移动时间
    private Action mOnMoveComplete; //移动完成回调
    
    private VInt mVintLerpTime = 0; //用于计算移动的时间
    
    private VInt3 mOriginPos; //原始位置
    /// <summary>
    /// 移动到指定位置的动作
    /// </summary>
    /// <param name="moveObject">要移动的对象</param>
    /// <param name="targetPos">目标位置</param>
    /// <param name="time">移动时间</param>
    /// <param name="OnMoveComplete">移动完成回调</param>
    public MoveToAction(LogicObject moveObject,VInt3 targetPos, VInt time, Action OnMoveComplete)
    {
        mMoveLogicObject = moveObject;
        mOriginPos = moveObject.logicPosition;
        mTargetPos = targetPos;
        mTime = time;
        mOnMoveComplete = OnMoveComplete;
    }

    public override void OnLogicFrameUpdate()
    {
        base.OnLogicFrameUpdate();
#if CLIENT_LOGIC
        mVintLerpTime += (VInt)LogicFrameSyncConfig.LogicFrameIntervalMs;
        VInt lerpValue = mVintLerpTime / mTime;
        //计算新的逻辑位置
        mMoveLogicObject.logicPosition = VInt3.Lerp(mOriginPos, mTargetPos, lerpValue.RawFloat);
        if (lerpValue > VInt.one)
        {
            //移动完成
            mOnMoveComplete?.Invoke();
            actionComplete = true;
            return;
        }
#else
        mOnMoveComplete?.Invoke();
        actionComplete = true;
#endif
    }
}
