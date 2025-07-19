using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicFrameSyncConfig
{
    public static long LogicFrameId; //逻辑帧id 自增
    private static readonly float LogicFrameInterval = 0.066f; // 1秒15帧
    public static float LogicFrameIntervalMs => LogicFrameInterval * 1000f; // 毫秒
}
