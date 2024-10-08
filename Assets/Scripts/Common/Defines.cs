using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 常量类
/// </summary>
public static class Defines
{
    //控制器相关的常量
    public static readonly string OpenStartView = "OpenStartView"; //开启开始面板
    public static readonly string OpenSetView = "OpenSetView"; //
    public static readonly string OpenMessageView = "OpenMessageView"; //
    public static readonly string OpenSelectLevelView = "OpenSelectLevelView"; //
    public static readonly string LoadingScene = "LoadingScene";
    public static readonly string BeginFight = "BeginFight";

    //全局事件
    public static readonly string ShowLevelDesEvent = "ShowLevelDesEvent";
    public static readonly string HideLevelDesEvent = "HideLevelDesEvent";

    public static readonly string OnSelectEvent = "OnSelectEvent"; //选中事件
    public static readonly string OnUnSelectEvent = "OnUnSelectEvent"; //未选中事件

    //option
    public static readonly string OnAttackEvent = "OnAttackEvent";
    public static readonly string OnIdleEvent = "OnIdleEvent";
    public static readonly string OnCancelEvent = "OnCancelEvent";
    public static readonly string OnRemoveHeroToSceneEvent = "OnRemoveHeroToSceneEvent";
}
