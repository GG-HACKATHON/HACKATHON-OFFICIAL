using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public GameObject hp;

    public Direction direction;

    public float health;

    protected float curHealth;

    protected Animator anim;

	public virtual void Init()
    {
        curHealth = health;
        anim = GetComponent<Animator>();
    }

    public virtual void OnHit(float dame)
    {
        curHealth -= dame;
        if (curHealth <= 0)
            Destroy(this.gameObject);

        float ratio = curHealth / health;

        Vector3 scale = new Vector3(ratio, 1, 1);

        hp.transform.localScale = scale;
    }

    public virtual void OnHit(BaseObject target, float dame)
    {
        target.health -= dame;
    }
}
