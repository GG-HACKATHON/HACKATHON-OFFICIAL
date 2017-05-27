using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : BaseItem
{

    public int Amount;
    
	


    protected override void OnDie()
    {
        GameController.Instance.AddDiamond(Amount);
    }

    
}
