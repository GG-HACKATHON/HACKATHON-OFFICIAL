﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : BaseItem {

    LinePlayer linePlayer;

    void Awake()
    {
        linePlayer = FindObjectOfType<LinePlayer>();
    }

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

    protected override void OnDie()
    {
        linePlayer.AddBody(ComradeType.PANDA, linePlayer.GetBodyCount());
    }
}
