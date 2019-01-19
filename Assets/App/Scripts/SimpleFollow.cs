using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour {

	public Transform followTransform;

	public float followSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, followTransform.position, Time.deltaTime * followSpeed);
		
	}
}
