using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFloat : MonoBehaviour {


	public float floatIntensity;
	public float floatSpeed;
	public float yPos;

	public Vector3 originalPosition;

	private float randomStart;

	Vector3 tempPos = new Vector3 ();


	// Use this for initialization
	void Start () {
		originalPosition = transform.position;

		randomStart = Random.Range (-1, 1);


	}
	
	// Update is called once per frame
	void Update () {

		tempPos = originalPosition;
		tempPos.z += Mathf.Sin (Time.fixedTime * Mathf.PI * floatSpeed + randomStart) * floatIntensity;

		transform.position = tempPos;
	
	}


	public Vector3 YOscillate()
	{
		var tempVect = new Vector3();

		tempVect.y = Mathf.Sin(Time.time) * 3;

		tempVect.y =+ originalPosition.y;

		return tempVect;
	}
}
