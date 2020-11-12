using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public Nensi nensi;

	// Use this for initialization
	void Start () {
        nensi = GameObject.FindGameObjectWithTag("Nensi").GetComponent<Nensi>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        offset.x = nensi.transform.position.x;
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset * Time.deltaTime /1f;
		
	}
}
