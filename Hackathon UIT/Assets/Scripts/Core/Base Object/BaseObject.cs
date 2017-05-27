using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour {
    public Direction direction;

    protected float health;

    protected Animator anim;

	public virtual void Init()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void OnHit(float dame)
    {
        health -= dame;
        if (health <= 0)
            Destroy(this.gameObject);
    }
}
