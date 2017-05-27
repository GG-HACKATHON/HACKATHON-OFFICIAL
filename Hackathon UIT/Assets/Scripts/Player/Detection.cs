using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

    public GameObject projectilePrefab;

    public float delayTime;

    private float currentTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
	}

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            if (currentTime <= 0.0f)
            {
                GameObject proj = GameObject.Instantiate(projectilePrefab,
                  transform.position,
                  Quaternion.identity);
                currentTime = delayTime;
            }
        }
    }


}
