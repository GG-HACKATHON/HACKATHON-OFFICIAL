using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Spawn
}

public class BaseItem : MonoBehaviour {

    protected ItemType type;

    public virtual void Init(ItemType type)
    {
        this.type = type;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
