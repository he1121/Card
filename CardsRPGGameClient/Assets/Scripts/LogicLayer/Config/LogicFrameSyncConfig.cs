using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicFrameSyncConfig
{
    public static long LogicFrameId; //逻辑帧id 自增
    public static float LogicFrameInterval = 0.066f; // 1秒15帧
    public static int LogicFrameIntervalMs => 66; // 毫秒
}
