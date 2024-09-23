using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : ModelBase,ISkill
{
    public SkillProperty skillPro { get; set; }
    public Slider hpSlider;
    
    
    protected override void Start()
    {
        base.Start();

         hpSlider = transform.Find("hp/bg").GetComponent<Slider>();
        
        data = GameApp.ConfigManager.GetConfigData("enemy").GetDataById(Id);

        Type = int.Parse(this.data["Type"]);
        Attack = int.Parse(this.data["Attack"]);
        Step = int.Parse(this.data["Step"]);
        MaxHp = int.Parse(this.data["Hp"]);
        CurHp = MaxHp;

        skillPro = new SkillProperty(int.Parse(data["Skill"]));
   
    }

    protected override void OnSelectCallBack(object args)
    {
        if (GameApp.CommandManager.IsRunningCommand == true)
        {
            return;
        }
        
        base.OnSelectCallBack(args);
        GameApp.ViewManager.Open(ViewType.EnemyDesView,this);
    }

    protected override void OnUnSelectCallBack(object args)
    {
        base.OnUnSelectCallBack(args);
        GameApp.ViewManager.Close(ViewType.EnemyDesView,this);
    }

    
    
    
    public void ShowSkillArea()
    {
       
    }

    public void HideSkillArea()
    {
    
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
            
            GameApp.FightWorldManager.RemoveEnemy(this);
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
        yield return new WaitForSeconds(0.75f);
        hpSlider.gameObject.SetActive(false);
    }
    
}
