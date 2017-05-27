using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;       
    
    protected virtual void FixedUpdate()
    {
       
        if (player != null)
        {
            Vector3 pos = player.transform.position;
            pos.z = transform.position.z;
            transform.position = pos;
        }
           
    }
}
