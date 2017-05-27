using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderAttack : MonoBehaviour {

    private Animator anim;

    public float timeDelay;

    private float curTime;

	// Use this for initialization
	void Start () {
        curTime = timeDelay;
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D target)
    {

    }
}
