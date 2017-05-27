using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderTrigger : MonoBehaviour {

	protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            // Nếu leader đụng vào tường thì chết
            BaseBody leader = GetComponent<BaseBody>();
            if (leader)
            {
                leader.linePlayer.OnDie();
            }
        }
    }
}
