using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

    public Projectile projectile;

    public float delayTime;

    public float speed;

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
                GameObject proj = Instantiate(projectile.gameObject,
                  transform.position,
                  Quaternion.identity);

                projectile.GetComponent<Projectile>().targetPosition = target.transform.position;                     

                currentTime = delayTime;
            }
        }
    }


}
