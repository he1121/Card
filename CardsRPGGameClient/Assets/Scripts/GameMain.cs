using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private void Awake()
    {
        WorldManager.Initialize();
    }

    private void Update()
    {
        WorldManager.OnUpdate();
    }

    private void OnDestroy()
    {
        WorldManager.DestroyWorld();
    }
}
