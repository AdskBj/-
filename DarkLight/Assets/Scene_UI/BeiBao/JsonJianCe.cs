using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonJianCe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<int> ks = new List<int>() { 1,2,3,4,5,6,7,8,9};
        Debug.Log(ks.ToString());
        Debug.Log("++++++++++++++++++++++");
        Debug.Log(JsonConvert.SerializeObject(ks));
        Debug.Log("++++++++++++++++++++++");
        Debug.Log(JsonConvert.SerializeObject(ks.ToString()));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
