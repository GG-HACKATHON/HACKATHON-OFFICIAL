using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBear : MonoBehaviour {

    public float timeToAttack;

    public float frameTime;

    public GameObject attackPrefab;

    public float currentTime;

    private float currentFrameTime;

    private Animator anim;

    private bool isChange;
	// Use this for initialization
	void Start () {
        anim = attackPrefab.GetComponent<Animator>();
        currentTime = 0;
        isChange = false;
	}

    // Update is called once per frame
    void Update()
    {
        if(currentTime<=0)
        {
            currentTime = timeToAttack;
            attackPrefab.SetActive(true);
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

        //if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            //attackPrefab.SetActive(false);

    }


}
