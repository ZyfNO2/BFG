using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 处理一些游戏通用ui的控制器(设置面板 提示面板 游戏开始面板等在这个控制器注册)
/// </summary>

public class GameUIController : BaseController
{
   public GameUIController() : base()
   {
      //注册视图

      //开始视图
      GameApp.ViewManager.Register(ViewType.StartView, new ViewInfo()
      {
         PrefabName = "StartView",
         controller = this,
         parentTf = GameApp.ViewManager.canvasTf
      });

      GameApp.ViewManager.Register(ViewType.SetView, new ViewInfo()
      {
         PrefabName = "SetView",
         controller = this,
         Sorting_Order = 1,//cover挡住开始面板，高层
         parentTf = GameApp.ViewManager.canvasTf
      });
      GameApp.ViewManager.Register(ViewType.MessageView, new ViewInfo()
      {
         PrefabName = "MessageView",
         controller = this,
         Sorting_Order = 999,//cover挡住开始面板，高层
         parentTf = GameApp.ViewManager.canvasTf
      });

      
      InitModuleEvent(); //初始化模板事件
      InitGlobalEvent(); //初始化全局事件
   }

   public override void InitModuleEvent()
   {
      RegisterFunc(Defines.OpenStartView, openStartView); //注册打开开始面板
      RegisterFunc(Defines.OpenSetView, openSetView); //注册打开开始面板
      RegisterFunc(Defines.OpenMessageView, openMessageView); //注册打开提示信息面板
   }
   
   //测试模板注册事件 例子
   private void openStartView(System.Object[] arg)
   {
      GameApp.ViewManager.Open(ViewType.StartView, arg);
   }
   //打开设置面板
   private void openSetView(System.Object[] arg)
   {
      GameApp.ViewManager.Open(ViewType.SetView, arg);
   }
   
   private void openMessageView(System.Object[] arg)
   {
      GameApp.ViewManager.Open(ViewType.MessageView, arg);
   }
   
   
}
