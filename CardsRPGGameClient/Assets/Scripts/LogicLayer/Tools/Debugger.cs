using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger
{
    public static void Log(object message)
    {
#if CLIENT_LOGIC
        Debug.Log(message);
#else
        Console.WriteLine(message);  // 在服务器端使用 Console.WriteLine 输出日志
#endif
    }
    
    public static void LogError(object message)
    {
#if CLIENT_LOGIC
        Debug.LogError(message);
#else
        Console.WriteLine(message);  // 在服务器端使用 Console.WriteLine 输出日志
#endif
    }
}
