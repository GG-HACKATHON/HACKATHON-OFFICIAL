using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunProjectile : Projectile {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(gameObject);
            target.GetComponent<BaseBody>().OnHit(dame);
        }
    }

}
 