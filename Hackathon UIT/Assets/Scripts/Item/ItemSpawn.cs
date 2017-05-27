using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemSpawn : BaseItem {

    public ComradeType typePlayer;
    public Sprite[] sprites;

    LinePlayer linePlayer;

    void Awake()
    {


        //typePlayer = (ComradeType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ComradeType)).Length);
        typePlayer = (ComradeType)(UnityEngine.Random.Range(0, 2));


        GetComponent<SpriteRenderer>().sprite = sprites[(int)typePlayer];

        linePlayer = FindObjectOfType<LinePlayer>();
    }

	// Use this for initialization
	//void Start () {
 //       Init(ItemType.Spawn);
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
    

    //public override void Init(ItemType type)
    //{
    //    base.Init(type);
    //}

    protected override void OnDie()
    {
        EffectManager.Instance.ApplyEffect(TYPE_FX.Shield, target.gameObject);
        linePlayer.AddBody(typePlayer, linePlayer.GetBodyCount());
    }
}
