
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//场景控制器
public class LoadingController : BaseController
{
    AsyncOperation asyncOp;
    
    public LoadingController():base() 
    {
        //×¢²áÊÓÍ¼

        GameApp.ViewManager.Register(ViewType.LoadingView, new ViewInfo()
        {
            PrefabName = "LoadingView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });

        InitModuleEvent();
    }

    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.LoadingScene, loadSceneCallback);
    }
    //加载回调
    private void loadSceneCallback(System.Object[] arg)
    {
        LoadingModel loadingModel = arg[0] as LoadingModel;

        SetModel(loadingModel);

        //打开加载
        GameApp.ViewManager.Open(ViewType.LoadingView);

        //加载场景
        asyncOp = SceneManager.LoadSceneAsync(loadingModel.SceneName);

        asyncOp.completed += onLoadedEndCallBack;
    }
    
    private void onLoadedEndCallBack(AsyncOperation asyncOp)
    {
        asyncOp.completed -= onLoadedEndCallBack;
        
        //延迟一点点
        GameApp.TimerManager.Register(0.25f, delegate()
        {
            GetModel<LoadingModel>().callback?.Invoke();
        
            GameApp.ViewManager.Close((int)ViewType.LoadingView);
        });

        
    }
    
    
}
