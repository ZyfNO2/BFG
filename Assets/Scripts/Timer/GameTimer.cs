using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer
{
    private List<GameTimerData> timerList;

    public GameTimer()
    {
        timerList = new List<GameTimerData>();
    }

    public void Register(float timer, System.Action callback)
    {
        GameTimerData data = new GameTimerData(timer, callback);
        timerList.Add(data);
    }

    public void OnUpdate(float dt)
    {
        for (int i = timerList.Count - 1; i >= 0; i--)
        {
            if (timerList[i].OnUpdate(dt))
            {
                timerList.RemoveAt(i);
            }
        }
    }
    /// <summary>
    /// 打断计时器
    /// </summary>
    public void Break()
    {
        timerList.Clear();
    }

    public int Count()
    {
        return timerList.Count;
    }
}