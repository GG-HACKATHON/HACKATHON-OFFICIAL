using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public GameObject hp;
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
        {
            //EffectManager.Instance.ApplyEffect(TYPE_FX.Collision, this.gameObject);
            Destroy(this.gameObject);
        }
        float ratio = curHealth / health;

        Vector3 scale = new Vector3(ratio, 1, 1);

        hp.transform.localScale = scale;
    }

    public virtual void OnHit(BaseObject target, float dame)
    {
        target.health -= dame;
    }

    public virtual void SetMoveAnimation(Direction dir)
    {
        switch (dir)
        {
            case Direction.LEFT:
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;
            case Direction.RIGHT:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;
            case Direction.UP:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", true);
                anim.SetBool("isDown", false);
                break;
            case Direction.DOWN:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", true);
                break;
        }
    }
}
