using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager:Singleton<ResourcesManager>
{
    public GameObject LoadObject(string path, Transform parent = null, bool resetPos = false, bool resetRot = false,
        bool resetScale = false)
    {
        GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(path), parent);
        if (resetPos)
        {
            obj.transform.localPosition = Vector3.zero;
        }
        if (resetRot)
        {
            obj.transform.localRotation = Quaternion.identity;
        }

        if (resetScale)
        {
            obj.transform.localScale = Vector3.one;
        }

        return obj;
    }
    
    /// <summary>
    /// 加载对象并获取对象身上的组件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadObject<T>(string path, Transform parent = null)
    {
        GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(path), parent);
        T t = obj.GetComponent<T>();
        return t;
    }

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadAsset<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
}
