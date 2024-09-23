using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例
/// </summary>
public class Singleton<T>
{
    private static readonly T instance = Activator.CreateInstance<T>();

    public static T Instance => instance;

    //初始化
    public virtual void Init()
    {

    }

    //每帧执行

    public virtual void Update(float dt)
    {

    }
    
    //释放
    public virtual void onDestroy()
    {

    }
}