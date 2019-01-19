using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelManager : MonoBehaviour {

	public bool swipeDown;
	public bool swipeUp;

	public Text yPos;

	public Transform infoUp;
	public Transform infoDown;

	void OnEnable()
	{
		SwipeDetector.SwipeDown += InfoPanelDown;
		SwipeDetector.SwipeUp += InfoPanelUp;
	}

	void OnDisable()
	{
		SwipeDetector.SwipeDown -= InfoPanelDown;
		SwipeDetector.SwipeUp += InfoPanelUp;

	}
		

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (swipeDown) 
		{
			transform.position = Vector3.Lerp(transform.position, infoDown.transform.position, Time.deltaTime * 1.5F);
			//transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -1280, 0), Time.deltaTime * 1.5F);
		}

		if (swipeUp) 
		{
			transform.position = Vector3.Lerp(transform.position, infoUp.transform.position, Time.deltaTime * 1.5F);
			//transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 1280, 0), Time.deltaTime * 1.5F);

		}

		yPos.text = transform.position.y.ToString ();
			
		
	}

	void InfoPanelDown()
	{
		swipeDown = true;
		swipeUp = false;
		//transform.position = Vector3.Lerp(transform.position, new Vector3(0, -2560, 0), Time.deltaTime * 1.5F);
	}

	void InfoPanelUp()
	{
		swipeUp = true;
		swipeDown = false;
	}

		
		
}
