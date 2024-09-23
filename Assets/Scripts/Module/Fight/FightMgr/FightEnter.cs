using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnter : FightUnitBase
{
   public override void Init()
   {
      GameApp.MapManager.Init();
      
      GameApp.FightWorldManager.EnterFight();
   }
}
