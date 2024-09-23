using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModel 
{
    public BaseController controller;
    public BaseModel(BaseController ctl)
    {
        this.controller = ctl;
    }

    public BaseModel()
    {

    }

    public virtual void Init()
    {


    } 

}
