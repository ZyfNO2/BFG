using UnityEngine;

public enum BlockType
{
    Null,
    Obstacle,
}

public class Block : MonoBehaviour
{
    public int RowIndex; //行
    public int ColIndex; //列
    public BlockType Type; //格子类型
    private SpriteRenderer selectSp; //选中的格子图片
    private SpriteRenderer gridSp; //网格图片
    private SpriteRenderer dirSp; //移动方向图片

    private void Awake()
    {
        selectSp = transform.Find("select").GetComponent<SpriteRenderer>();
        gridSp = transform.Find("grid").GetComponent<SpriteRenderer>();
        dirSp = transform.Find("dir").GetComponent<SpriteRenderer>();

        GameApp.MessageCenter.AddEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MessageCenter.AddEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    private void OnDestroy()
    {
        GameApp.MessageCenter.RemoveEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MessageCenter.RemoveEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    public void ShowGrid(Color color)
    {
        gridSp.enabled = true;
        gridSp.color = color;
    }

    public void HideGrid()
    {
        gridSp.enabled = false; 
    }

    void OnSelectCallBack(System.Object args)
    {
        GameApp.MessageCenter.PostEvent(Defines.OnUnSelectEvent);
        if (GameApp.CommandManager.IsRunningCommand == false)
        {
            GameApp.ViewManager.Open(ViewType.FightOptionDesView);
        }
    }

    void OnUnSelectCallBack(System.Object args)
    {

        dirSp.sprite = null;
        GameApp.ViewManager.Close(ViewType.FightOptionDesView);

    }

    private void OnMouseEnter()
    {
        selectSp.enabled = true;
    }

    private void OnMouseExit()
    {
        selectSp.enabled = false;
    }
    
    //设置箭头方向的图片资源 和 颜色
    public void SetDirSp(Sprite sp, Color color)
    {
        dirSp.sprite = sp;
        dirSp.color = color;
    }
}