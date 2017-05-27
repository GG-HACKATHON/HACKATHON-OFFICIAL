using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunProjectile : Projectile {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(gameObject);
            target.GetComponent<BaseObject>().OnHit(dame);
        }
    }

}
