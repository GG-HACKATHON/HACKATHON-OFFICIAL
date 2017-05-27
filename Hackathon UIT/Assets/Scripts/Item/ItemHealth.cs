using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : BaseItem
{
    public int Amount;
    LinePlayer linePlayer;

    void Awake()
    {
        linePlayer = FindObjectOfType<LinePlayer>();
    }
    

    protected override void OnDie()
    {
        linePlayer.AddHP(Amount);
    }


}
