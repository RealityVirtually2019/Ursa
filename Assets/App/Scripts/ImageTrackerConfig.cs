using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(TrackableBehaviour))]
public class ImageTrackerConfig : MonoBehaviour, ITrackableEventHandler {

	public Action TrackingDetected;
	public Action TrackingLost;

	private TrackableBehaviour imageTracker;
	public GameObject[] trackerObjects;
	public string trackerText;

	[HideInInspector]
	public bool isTracked;

	void Awake()
	{
		imageTracker = GetComponent<TrackableBehaviour> ();
	}

	// Use this for initialization
	void Start () {

		if (imageTracker) 
		{
			imageTracker.RegisterTrackableEventHandler(this);
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTrackableStateChanged(

		TrackableBehaviour.Status previousStatus,

		TrackableBehaviour.Status newStatus)

	{

		if (newStatus == TrackableBehaviour.Status.DETECTED ||

			newStatus == TrackableBehaviour.Status.TRACKED ||

			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)

		{

			// When target is found

			OnTrackingDetected ();

		}

		else

		{

			// When target is lost

			OnTrackingLost ();

		}

	}


	public void OnTrackingDetected()
	{
		isTracked = true;

		ShowObjects ();

		if (TrackingDetected != null)
			TrackingDetected ();

	}

	public void OnTrackingLost()
	{
		isTracked = false;

		HideObjects ();

		if (TrackingLost != null)
			TrackingLost ();


	}

	void ShowObjects()
	{
		foreach (var Go in trackerObjects) 
		{
			if (Go != null)
				Go.SetActive (true);
		}
	}


	void HideObjects()
	{
		foreach (var Go in trackerObjects) 
		{
			if (Go != null)
				Go.SetActive (false);
		}
	}

}
