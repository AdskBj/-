using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFloor : MonoBehaviour {

    Vector3 offset;
    public float distance,Speed;
     Transform player;
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
        offset = transform.forward * distance;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position =Vector3.Lerp(transform.position,player.position - offset,Speed*Time.deltaTime);
	}
}
