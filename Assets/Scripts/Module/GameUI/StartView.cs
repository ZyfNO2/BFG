using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开始游戏界面
/// </summary>
public class StartView : BaseView
{
   protected override void OnAwake()
   {
      base.OnAwake();
      
      Find<Button>("startBtn").onClick.AddListener(onStartGameBtn);
      Find<Button>("setBtn").onClick.AddListener(onSetBtn);
      Find<Button>("quitBtn").onClick.AddListener(onQuitGameBtn);
      
      
   }
   //开始游戏
   private void onStartGameBtn()
   {
      //关闭开始界面
      GameApp.ViewManager.Close(ViewId);
      
      LoadingModel loadingModel = new LoadingModel();
      loadingModel.SceneName = "map";
      loadingModel.callback = delegate()
      {
         //打开关卡选择
         Controller.ApplyControllerFunc(ControllerType.Level,Defines.OpenSelectLevelView);

      };
      Controller.ApplyControllerFunc(ControllerType.Loading,Defines.LoadingScene,loadingModel);

   }
   
   //设置按钮
   private void onSetBtn()
   {
      ApplyFunc(Defines.OpenSetView);
   }

   private void onQuitGameBtn()
   {
      Controller.ApplyControllerFunc(ControllerType.GameUI,Defines.OpenMessageView,new MessageInfo()
      {
         okCallback = delegate()
         {
            Application.Quit();
         },
         
         MsgTxt = "确定退出游戏吗？"
         
      });
   }
   
   
   
  
   
   
}