using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : BaseItem
{

    public int Amount;

	// Use this for initialization
	void Start ()
    {
		
	}

	void Update ()
    {
		
	}


    protected override void OnDie()
    {
        GameController.Instance.AddDiamond(Amount);
    }

    
}
