using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public Transform panelPopup;
    public int index;
    private object data;

    public virtual void OnShow(object data)
    {
        this.data = data;
    }
    public virtual void OnHide()
    { }
    public virtual void NextScene()
    { }
    public virtual void PrevScene()
    { }
    public virtual void Init()
    { }

}
