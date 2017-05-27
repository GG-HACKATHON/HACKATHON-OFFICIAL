using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        BaseBody leader = GetComponent<BaseBody>();

        if (col.tag == "Wall")
        {
            // Nếu leader đụng vào tường thì chết
            if (leader)
            {
                leader.linePlayer.OnDie();
            }
        }

  
        if (col.tag == "Enemy")
        {
            leader.OnHit(5);
            //Destroy(col.gameObject);
        }
    }
}
