using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : BaseItem {

	// Use this for initialization
	void Start () {
        Init(ItemType.Spawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Init(ItemType type)
    {
        base.Init(type);
    }
}
