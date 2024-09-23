using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Hero : ModelBase,ISkill
{
    public SkillProperty skillPro { get; set; }
    public Slider hpSlider;


    protected override void Start()
    {
        base.Start();
        hpSlider = transform.Find("hp/bg").GetComponent<Slider>();
    }
    
    public void Init(Dictionary<string, string> data, int row, int col)
    {
        this.data = data;
        this.RowIndex = row;
        this.ColIndex = col;
        Id = int.Parse(this.data["Id"]);
        Type = int.Parse(this.data["Type"]);
        Attack = int.Parse(this.data["Attack"]);
        Step = int.Parse(this.data["Step"]);
        MaxHp = int.Parse(this.data["Hp"]);
        CurHp = MaxHp;
        skillPro = new SkillProperty(int.Parse(this.data["Skill"]));
    }

    protected override void OnSelectCallBack(object args)
    {
        if (GameApp.FightWorldManager.state == GameState.Player)
        {
            
            if (GameApp.CommandManager.IsRunningCommand)
            {
                return;
            }
            //执行未选中
            GameApp.MessageCenter.PostEvent(Defines.OnUnSelectEvent);
            
            
            
            if (IsStop == false) 
            {
                //添加显示路径
                GameApp.MapManager.ShowStepGrid(this, Step);
                //添加显示路径指令
                GameApp.CommandManager.AddCommand(new ShowPathCommand(this));
                //添加选项事件
                addOptionEvents();
            }
            GameApp.ViewManager.Open(ViewType.HeroDesView,this);
        }
        
    }
    
    private void addOptionEvents()
    {
        GameApp.MessageCenter.AddTmpEvent(Defines.OnAttackEvent, onAttackCallBack);
        GameApp.MessageCenter.AddTmpEvent(Defines.OnIdleEvent, onIdleCallBack);
        GameApp.MessageCenter.AddTmpEvent(Defines.OnCancelEvent, onCancelCallBack);
    }
    
    private void onAttackCallBack(System.Object arg)
    {
        GameApp.CommandManager.AddCommand(new ShowSkillAreaCommand(this));
        
        Debug.Log("Attack");
        
    }

    private void onIdleCallBack(System.Object arg)
    {
        IsStop = true;
        Debug.Log("idle");
    }

    private void onCancelCallBack(System.Object arg)
    {
        GameApp.CommandManager.UnDo();
    }
    
    protected override void OnUnSelectCallBack(object args)
    {
        base.OnUnSelectCallBack(args);
        GameApp.ViewManager.Close(ViewType.HeroDesView,this);
    }


   
    
    public void ShowSkillArea()
    {
        GameApp.MapManager.ShowAttackStep(this,skillPro.AttackRange,Color.red);
    }

    public void HideSkillArea()
    {
        GameApp.MapManager.HideAttackStep(this,skillPro.AttackRange);
    }

    public override void GetHit(ISkill skill)
    {
        GameApp.SoundManager.PlayEffect("hit",transform.position);

        CurHp -= skill.skillPro.Attack;
        
        GameApp.ViewManager.ShowHitNum($"-{skill.skillPro.Attack}",Color.red,transform.position );

        PlayEffect(skill.skillPro.AttackEffect);

        if (CurHp <= 0)
        {
            CurHp = 0;
            
            PlayAni("die");
            
            Destroy(gameObject,1.2f);
            
            GameApp.FightWorldManager.RemoveHero(this);
        }
        StopAllCoroutines();
        StartCoroutine(ChangeColor());
        StartCoroutine(UpdateHpSlider()); 
    }
    private IEnumerator ChangeColor()
    {
        bodySp.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.25f);
        bodySp.material.SetFloat("_FlashAmount", 0);
    }
    
    private IEnumerator UpdateHpSlider()
    {
        hpSlider.gameObject.SetActive(true);
        hpSlider.DOValue((float)CurHp / (float)MaxHp, 0.25f);
        yield return new  WaitForSeconds(0.75f);
        hpSlider.gameObject.SetActive(false);
    }
    
    
    
}