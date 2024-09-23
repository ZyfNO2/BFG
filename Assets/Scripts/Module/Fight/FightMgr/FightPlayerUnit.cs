using System.Collections.Generic;
using UnityEngine;

//Íæ¼ÒµÄ»ØºÏ
public class FightPlayerUnit : FightUnitBase
{
    public override void Init()
    {
        base.Init();
        GameApp.FightWorldManager.ResetEnemies();
        GameApp.ViewManager.Open(ViewType.TipView, "PlauerTurn");
    }
}