﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomProjectile : Projectile {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Exploisive"))
        {
            anim.Stop();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            //Destroy(gameObject);
            anim.SetBool("isExploisive", true);
            Vector3 scale = new Vector3(4.5f, 4.5f, 4.5f);
            gameObject.transform.localScale = scale;
            target.GetComponent<BaseObject>().OnHit(dame);

        }
    }
}
